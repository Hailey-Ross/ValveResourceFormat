using System;
using System.Collections.Generic;
using GUI.Types.Renderer;
using GUI.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ValveResourceFormat.ResourceTypes;
using ValveResourceFormat.Serialization;

namespace GUI.Types.ParticleRenderer.Renderers
{
    internal class RenderSprites : IParticleRenderer
    {
        private const int VertexSize = 9;

        private readonly Shader shader;
        private readonly int quadVao;
        private readonly int glTexture;

        private readonly Texture.SpritesheetData spriteSheetData;
        private readonly float animationRate = 0.1f;

        private readonly bool additive;
        private readonly float overbrightFactor = 1;
        private readonly long orientationType = 0;

        private float[] cpuVertexData;
        private QuadIndexBuffer quadIndices;
        private int vertexBufferHandle;

        public RenderSprites(IKeyValueCollection keyValues, VrfGuiContext vrfGuiContext)
        {
            shader = vrfGuiContext.ShaderLoader.LoadShader("vrf.particle.sprite", new Dictionary<string, bool>());
            quadIndices = vrfGuiContext.QuadIndices;

            // The same quad is reused for all particles
            quadVao = SetupQuadBuffer();

            if (keyValues.ContainsKey("m_hTexture"))
            {
                var textureSetup = LoadTexture(keyValues.GetProperty<string>("m_hTexture"), vrfGuiContext);
                glTexture = textureSetup.TextureIndex;
                spriteSheetData = textureSetup.TextureData?.GetSpriteSheetData();
            }
            else
            {
                glTexture = vrfGuiContext.MaterialLoader.GetErrorTexture();
            }

            additive = keyValues.GetProperty<bool>("m_bAdditive");
            if (keyValues.ContainsKey("m_flOverbrightFactor"))
            {
                overbrightFactor = keyValues.GetFloatProperty("m_flOverbrightFactor");
            }

            if (keyValues.ContainsKey("m_nOrientationType"))
            {
                orientationType = keyValues.GetIntegerProperty("m_nOrientationType");
            }

            if (keyValues.ContainsKey("m_flAnimationRate"))
            {
                animationRate = keyValues.GetFloatProperty("m_flAnimationRate");
            }
        }

        private int SetupQuadBuffer()
        {
            GL.UseProgram(shader.Program);

            // Create and bind VAO
            var vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            vertexBufferHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferHandle);

            int stride = sizeof(float) * VertexSize;
            var positionAttributeLocation = GL.GetAttribLocation(shader.Program, "aVertexPosition");
            GL.VertexAttribPointer(positionAttributeLocation, 3, VertexAttribPointerType.Float, false, stride, 0);
            var colorAttributeLocation = GL.GetAttribLocation(shader.Program, "aVertexColor");
            GL.VertexAttribPointer(colorAttributeLocation, 4, VertexAttribPointerType.Float, false, stride, sizeof(float) * 3);
            var uvAttributeLocation = GL.GetAttribLocation(shader.Program, "aTexCoords");
            GL.VertexAttribPointer(uvAttributeLocation, 2, VertexAttribPointerType.Float, false, stride, sizeof(float) * 7);

            GL.EnableVertexAttribArray(positionAttributeLocation);
            GL.EnableVertexAttribArray(colorAttributeLocation);
            GL.EnableVertexAttribArray(uvAttributeLocation);

            GL.BindVertexArray(0);

            return vao;
        }

        private (int TextureIndex, Texture TextureData) LoadTexture(string textureName, VrfGuiContext vrfGuiContext)
        {
            var textureResource = vrfGuiContext.LoadFileByAnyMeansNecessary(textureName + "_c");

            if (textureResource == null)
            {
                return (vrfGuiContext.MaterialLoader.GetErrorTexture(), null);
            }

            return (vrfGuiContext.MaterialLoader.LoadTexture(textureName), (Texture)textureResource.DataBlock);
        }

        private void EnsureSpaceForVertices(int count)
        {
            int numFloats = count * VertexSize;

            if (cpuVertexData == null)
            {
                cpuVertexData = new float[numFloats];
            }
            else if (cpuVertexData.Length < numFloats)
            {
                int nextSize = (((count / 64) + 1) * 64) * VertexSize;
                Array.Resize(ref cpuVertexData, nextSize);
            }
        }

        public void Render(ParticleBag particleBag, Matrix4 projectionMatrix, Matrix4 modelViewMatrix)
        {
            if (particleBag.Count == 0)
            {
                return;
            }

            var particles = particleBag.LiveParticles;
            var modelViewRotation = modelViewMatrix.ExtractRotation().Inverted(); // Create billboarding rotation (always facing camera)
            var billboardMatrix = Matrix4.CreateFromQuaternion(modelViewRotation);

            // Update vertex buffer
            EnsureSpaceForVertices(particleBag.Count * 4);
            for (int i = 0; i < particleBag.Count; ++i)
            {
                // Positions
                var modelMatrix = orientationType == 0
                    ? particles[i].GetRotationMatrix() * billboardMatrix * particles[i].GetTransformationMatrix()
                    : particles[i].GetRotationMatrix() * particles[i].GetTransformationMatrix();

                var tl = new Vector4(-1, -1, 0, 1) * modelMatrix;
                var bl = new Vector4(-1, 1, 0, 1) * modelMatrix;
                var br = new Vector4(1,  1, 0, 1) * modelMatrix;
                var tr = new Vector4(1, -1, 0, 1) * modelMatrix;

                int quadStart = i * VertexSize * 4;
                cpuVertexData[quadStart + 0] = tl.X;
                cpuVertexData[quadStart + 1] = tl.Y;
                cpuVertexData[quadStart + 2] = tl.Z;
                cpuVertexData[quadStart + (VertexSize * 1) + 0] = bl.X;
                cpuVertexData[quadStart + (VertexSize * 1) + 1] = bl.Y;
                cpuVertexData[quadStart + (VertexSize * 1) + 2] = bl.Z;
                cpuVertexData[quadStart + (VertexSize * 2) + 0] = br.X;
                cpuVertexData[quadStart + (VertexSize * 2) + 1] = br.Y;
                cpuVertexData[quadStart + (VertexSize * 2) + 2] = br.Z;
                cpuVertexData[quadStart + (VertexSize * 3) + 0] = tr.X;
                cpuVertexData[quadStart + (VertexSize * 3) + 1] = tr.Y;
                cpuVertexData[quadStart + (VertexSize * 3) + 2] = tr.Z;

                // Colors
                for (int j = 0; j < 4; ++j)
                {
                    cpuVertexData[quadStart + (VertexSize * j) + 3] = particles[i].Color.X;
                    cpuVertexData[quadStart + (VertexSize * j) + 4] = particles[i].Color.Y;
                    cpuVertexData[quadStart + (VertexSize * j) + 5] = particles[i].Color.Z;
                    cpuVertexData[quadStart + (VertexSize * j) + 6] = particles[i].Alpha;
                }

                // UVs
                if (spriteSheetData != null && spriteSheetData.Sequences.Length > 0 && spriteSheetData.Sequences[0].Frames.Length > 0)
                {
                    var sequence = spriteSheetData.Sequences[particles[i].Sequence % spriteSheetData.Sequences.Length];

                    var particleTime = particles[i].ConstantLifetime - particles[i].Lifetime;
                    var frame = particleTime * sequence.FramesPerSecond * animationRate;

                    var currentFrame = sequence.Frames[(int)Math.Floor(frame) % sequence.Frames.Length];

                    // Lerp frame coords and size
                    var subFrameTime = frame % 1.0f;
                    var offset = (currentFrame.StartMins * (1 - subFrameTime)) + (currentFrame.EndMins * subFrameTime);
                    var scale = ((currentFrame.StartMaxs - currentFrame.StartMins) * (1 - subFrameTime))
                            + ((currentFrame.EndMaxs - currentFrame.EndMins) * subFrameTime);

                    cpuVertexData[quadStart + (VertexSize * 0) + 7] = offset.X + (scale.X * 0);
                    cpuVertexData[quadStart + (VertexSize * 0) + 8] = offset.Y + (scale.Y * 1);
                    cpuVertexData[quadStart + (VertexSize * 1) + 7] = offset.X + (scale.X * 0);
                    cpuVertexData[quadStart + (VertexSize * 1) + 8] = offset.Y + (scale.Y * 0);
                    cpuVertexData[quadStart + (VertexSize * 2) + 7] = offset.X + (scale.X * 1);
                    cpuVertexData[quadStart + (VertexSize * 2) + 8] = offset.Y + (scale.Y * 0);
                    cpuVertexData[quadStart + (VertexSize * 3) + 7] = offset.X + (scale.X * 1);
                    cpuVertexData[quadStart + (VertexSize * 3) + 8] = offset.Y + (scale.Y * 1);
                }
                else
                {
                    cpuVertexData[quadStart + (VertexSize * 0) + 7] = 0;
                    cpuVertexData[quadStart + (VertexSize * 0) + 8] = 1;
                    cpuVertexData[quadStart + (VertexSize * 1) + 7] = 0;
                    cpuVertexData[quadStart + (VertexSize * 1) + 8] = 0;
                    cpuVertexData[quadStart + (VertexSize * 2) + 7] = 1;
                    cpuVertexData[quadStart + (VertexSize * 2) + 8] = 0;
                    cpuVertexData[quadStart + (VertexSize * 3) + 7] = 1;
                    cpuVertexData[quadStart + (VertexSize * 3) + 8] = 1;
                }
            }

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, particleBag.Count * VertexSize * 4 * sizeof(float), cpuVertexData, BufferUsageHint.DynamicDraw);

            // Draw it
            GL.Enable(EnableCap.Blend);
            GL.UseProgram(shader.Program);

            if (additive)
            {
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.One);
            }
            else
            {
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            }

            GL.BindVertexArray(quadVao);
            GL.EnableVertexAttribArray(0);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, glTexture);

            GL.Uniform1(shader.GetUniformLocation("uTexture"), 0); // set texture unit 0 as uTexture uniform
            GL.UniformMatrix4(shader.GetUniformLocation("uProjectionMatrix"), false, ref projectionMatrix);
            GL.UniformMatrix4(shader.GetUniformLocation("uModelViewMatrix"), false, ref modelViewMatrix);

            // TODO: This formula is a guess but still seems too bright compared to valve particles
            GL.Uniform1(shader.GetUniformLocation("uOverbrightFactor"), overbrightFactor);

            GL.Disable(EnableCap.CullFace);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, quadIndices.GLHandle);
            GL.DrawElements(BeginMode.Triangles, particleBag.Count * 6, DrawElementsType.UnsignedShort, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.Enable(EnableCap.CullFace);

            /*
            for (int i = 0; i < particles.Length; ++i)
            {
                var modelMatrix = orientationType == 0
                    ? particles[i].GetRotationMatrix() * billboardMatrix * particles[i].GetTransformationMatrix()
                    : particles[i].GetRotationMatrix() * particles[i].GetTransformationMatrix();

                // Position/Radius uniform
                GL.UniformMatrix4(modelMatrixLocation, false, ref modelMatrix);

                if (spriteSheetData != null && spriteSheetData.Sequences.Length > 0 && spriteSheetData.Sequences[0].Frames.Length > 0)
                {
                    var sequence = spriteSheetData.Sequences[particles[i].Sequence % spriteSheetData.Sequences.Length];

                    var particleTime = particles[i].ConstantLifetime - particles[i].Lifetime;
                    var frame = particleTime * sequence.FramesPerSecond * animationRate;

                    var currentFrame = sequence.Frames[(int)Math.Floor(frame) % sequence.Frames.Length];

                    // Lerp frame coords and size
                    var subFrameTime = frame % 1.0f;
                    var offset = (currentFrame.StartMins * (1 - subFrameTime)) + (currentFrame.EndMins * subFrameTime);
                    var scale = ((currentFrame.StartMaxs - currentFrame.StartMins) * (1 - subFrameTime))
                            + ((currentFrame.EndMaxs - currentFrame.EndMins) * subFrameTime);

                    GL.Uniform2(uvOffsetLocation, offset.X, offset.Y);
                    GL.Uniform2(uvScaleLocation, scale.X, scale.Y);
                }
                else
                {
                    GL.Uniform2(uvOffsetLocation, 1f, 1f);
                    GL.Uniform2(uvScaleLocation, 1f, 1f);
                }

                // Color uniform
                GL.Uniform3(colorLocation, particles[i].Color.X, particles[i].Color.Y, particles[i].Color.Z);

                GL.Uniform1(alphaLocation, particles[i].Alpha * particles[i].AlphaAlternate);

                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
            }
            */

            GL.BindVertexArray(0);
            GL.UseProgram(0);

            if (additive)
            {
                GL.BlendEquation(BlendEquationMode.FuncAdd);
            }

            GL.Disable(EnableCap.Blend);
        }
    }
}
