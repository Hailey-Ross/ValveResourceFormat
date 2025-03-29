// Copyright 2020 lewa_j [https://github.com/lewa-j]
// Reference: https://registry.khronos.org/DataFormat/specs/1.3/dataformat.1.3.html#bptc_bc6h
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SkiaSharp;

namespace ValveResourceFormat.TextureDecoders
{
    internal class DecodeBC6H : CommonBPTC, ITextureDecoder
    {
        readonly int blockCountX;
        readonly int blockCountY;

        public DecodeBC6H(int width, int height)
        {
            blockCountX = (width + 3) / 4;
            blockCountY = (height + 3) / 4;
        }

        public void Decode(SKBitmap bitmap, Span<byte> input)
        {
            using var pixels = bitmap.PeekPixels();
            var data = pixels.GetPixelSpan<byte>();
            var rowBytes = bitmap.RowBytes;
            var offset = 0;

            var endpoints = new int[4, 3];
            var deltas = new short[3, 3];

            for (var j = 0; j < blockCountY; j++)
            {
                for (var i = 0; i < blockCountX; i++)
                {
                    var block0 = BitConverter.ToUInt64(input.Slice(offset, sizeof(ulong)));
                    offset += sizeof(ulong);
                    var block64 = BitConverter.ToUInt64(input.Slice(offset, sizeof(ulong)));
                    offset += sizeof(ulong);

                    ulong Bit(int p)
                    {
                        return (byte)(p < 64 ? block0 >> p & 1 : block64 >> (p - 64) & 1);
                    }

                    var m = (byte)(block0 & 0x3);
                    if (m >= 2)
                    {
                        m = (byte)(block0 & 0x1F);
                    }

                    Array.Clear(endpoints, 0, endpoints.Length);
                    Array.Clear(deltas, 0, deltas.Length);

                    var wBits = 0;
                    byte pb = 0;
                    ulong ib = 0;

                    if (m == 0)
                    {
                        wBits = 10;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0x3FF);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0x3FF);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0x3FF);
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x1F, 5);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x1F, 5);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x1F, 5);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x1F, 5);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(2) << 4), 5);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(3) << 4), 5);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x1F, 5);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | (Bit(40) << 4), 5);
                        deltas[2, 2] = SignExtend(Bit(50) | (Bit(60) << 1) | (Bit(70) << 2) | (Bit(76) << 3) | (Bit(4) << 4), 5);
                    }
                    else if (m == 1)
                    {
                        wBits = 7;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0x7F);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0x7F);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0x7F);
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x3F, 6);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x3F, 6);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x3F, 6);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x3F, 6);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(24) << 4) | (Bit(2) << 5), 6);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(14) << 4) | (Bit(22) << 5), 6);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x3F, 6);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | ((block0 >> 3 & 0x3) << 4), 6);
                        deltas[2, 2] = SignExtend((block0 >> 12 & 0x3) | (Bit(23) << 2) | (Bit(32) << 3) | (Bit(34) << 4) | (Bit(33) << 5), 6);
                    }
                    else if (m == 2)
                    {
                        wBits = 11;
                        endpoints[0, 0] = (ushort)((block0 >> 5 & 0x3FF) | (Bit(40) << 10));
                        endpoints[0, 1] = (ushort)((block0 >> 15 & 0x3FF) | (Bit(49) << 10));
                        endpoints[0, 2] = (ushort)((block0 >> 25 & 0x3FF) | (Bit(59) << 10));
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x1F, 5);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0xF, 4);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0xF, 4);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x1F, 5);
                        deltas[1, 1] = SignExtend(block0 >> 41 & 0xF, 4);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3), 4);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x1F, 5);
                        deltas[2, 1] = SignExtend(block0 >> 51 & 0xF, 4);
                        deltas[2, 2] = SignExtend(Bit(50) | (Bit(60) << 1) | (Bit(70) << 2) | (Bit(76) << 3), 4);
                    }
                    else if (m == 6)
                    {
                        wBits = 11;
                        endpoints[0, 0] = (ushort)((block0 >> 5 & 0x3FF) | (Bit(39) << 10));
                        endpoints[0, 1] = (ushort)((block0 >> 15 & 0x3FF) | (Bit(50) << 10));
                        endpoints[0, 2] = (ushort)((block0 >> 25 & 0x3FF) | (Bit(59) << 10));
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0xF, 4);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x1F, 5);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0xF, 4);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0xF, 4);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(75) << 4), 5);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3), 4);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0xF, 4);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | (Bit(40) << 4), 5);
                        deltas[2, 2] = SignExtend(Bit(69) | (Bit(60) << 1) | (Bit(70) << 2) | (Bit(76) << 3), 4);
                    }
                    else if (m == 10)
                    {
                        wBits = 11;
                        endpoints[0, 0] = (ushort)((block0 >> 5 & 0x3FF) | (Bit(39) << 10));
                        endpoints[0, 1] = (ushort)((block0 >> 15 & 0x3FF) | (Bit(49) << 10));
                        endpoints[0, 2] = (ushort)((block0 >> 25 & 0x3FF) | (Bit(60) << 10));
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0xF, 4);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0xF, 4);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x1F, 5);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0xF, 4);
                        deltas[1, 1] = SignExtend(block0 >> 41 & 0xF, 4);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(40) << 4), 5);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0xF, 4);
                        deltas[2, 1] = SignExtend(block0 >> 51 & 0xF, 4);
                        deltas[2, 2] = SignExtend(Bit(50) | (Bit(69) << 1) | (Bit(70) << 2) | (Bit(76) << 3) | (Bit(75) << 3), 5);
                    }
                    else if (m == 14)
                    {
                        wBits = 9;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0x1FF);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0x1FF);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0x1FF);
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x1F, 5);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x1F, 5);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x1F, 5);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x1F, 5);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(24) << 4), 5);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(14) << 4), 5);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x1F, 5);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | (Bit(40) << 4), 5);
                        deltas[2, 2] = SignExtend(Bit(50) | (Bit(60) << 1) | (Bit(70) << 2) | (Bit(76) << 3) | (Bit(34) << 4), 5);
                    }
                    else if (m == 18)
                    {
                        wBits = 8;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0xFF);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0xFF);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0xFF);
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x3F, 6);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x1F, 5);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x1F, 5);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x3F, 6);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(24) << 4), 5);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(14) << 4), 5);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x3F, 6);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | (Bit(13) << 4), 5);
                        deltas[2, 2] = SignExtend(Bit(50) | (Bit(60) << 1) | (Bit(23) << 2) | (Bit(33) << 3) | (Bit(34) << 4), 5);
                    }
                    else if (m == 22)
                    {
                        wBits = 8;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0xFF);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0xFF);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0xFF);
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x1F, 5);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x3F, 6);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x1F, 5);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x1F, 5);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(24) << 4) | (Bit(23) << 5), 6);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(14) << 4), 5);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x1F, 5);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | (Bit(40) << 4) | (Bit(33) << 5), 6);
                        deltas[2, 2] = SignExtend(Bit(13) | (Bit(60) << 1) | (Bit(70) << 2) | (Bit(76) << 3) | (Bit(34) << 4), 5);
                    }
                    else if (m == 26)
                    {
                        wBits = 8;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0xFF);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0xFF);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0xFF);
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x1F, 5);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x1F, 5);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x3F, 6);
                        deltas[1, 0] = SignExtend(block64 >> 1 & 0x1F, 5);
                        deltas[1, 1] = SignExtend((block0 >> 41 & 0xF) | (Bit(24) << 4), 5);
                        deltas[1, 2] = SignExtend((block0 >> 61 & 0x7) | (Bit(64) << 3) | (Bit(14) << 4) | (Bit(23) << 5), 6);
                        deltas[2, 0] = SignExtend(block64 >> 7 & 0x1F, 5);
                        deltas[2, 1] = SignExtend((block0 >> 51 & 0xF) | (Bit(40) << 4), 5);
                        deltas[2, 2] = SignExtend(Bit(50) | (Bit(13) << 1) | (Bit(70) << 2) | (Bit(76) << 3) | (Bit(34) << 4) | (Bit(33) << 5), 6);
                    }
                    else if (m == 30)
                    {
                        wBits = 6;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0x3F);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0x3F);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0x3F);
                        endpoints[1, 0] = (ushort)(block0 >> 35 & 0x3F);
                        endpoints[1, 1] = (ushort)(block0 >> 45 & 0x3F);
                        endpoints[1, 2] = (ushort)(block0 >> 55 & 0x3F);
                        endpoints[2, 0] = (ushort)(block64 >> 1 & 0x3F);
                        endpoints[2, 1] = (ushort)((block0 >> 41 & 0xF) | (Bit(24) << 4) | (Bit(21) << 5));
                        endpoints[2, 2] = (ushort)((block0 >> 61 & 0x3) | (Bit(64) << 3) | (Bit(14) << 4) | (Bit(22) << 5));
                        endpoints[3, 0] = (ushort)(block64 >> 7 & 0x3F);
                        endpoints[3, 1] = (ushort)((block0 >> 51 & 0xF) | (Bit(11) << 4) | (Bit(31) << 5));
                        endpoints[3, 2] = (ushort)((block0 >> 12 & 0x3) | (Bit(23) << 2) | (Bit(32) << 3) | (Bit(34) << 4) | (Bit(33) << 5));
                    }
                    else if (m == 3)
                    {
                        wBits = 10;
                        endpoints[0, 0] = (ushort)(block0 >> 5 & 0x3FF);
                        endpoints[0, 1] = (ushort)(block0 >> 15 & 0x3FF);
                        endpoints[0, 2] = (ushort)(block0 >> 25 & 0x3FF);
                        endpoints[1, 0] = (ushort)(block0 >> 35 & 0x3FF);
                        endpoints[1, 1] = (ushort)(block0 >> 45 & 0x3FF);
                        endpoints[1, 2] = (ushort)((block0 >> 55 & 0x1FF) | ((block64 & 0x1) << 9));
                    }
                    else if (m == 7)
                    {
                        wBits = 11;
                        endpoints[0, 0] = (ushort)((block0 >> 5 & 0x3FF) | (Bit(44) << 10));
                        endpoints[0, 1] = (ushort)((block0 >> 15 & 0x3FF) | (Bit(54) << 10));
                        endpoints[0, 2] = (ushort)((block0 >> 25 & 0x3FF) | (Bit(64) << 10));
                        deltas[0, 0] = SignExtend(block0 >> 35 & 0x1FF, 9);
                        deltas[0, 1] = SignExtend(block0 >> 45 & 0x1FF, 9);
                        deltas[0, 2] = SignExtend(block0 >> 55 & 0x1FF, 9);
                    }
                    else if (m == 11)
                    {
                        wBits = 12;
                        endpoints[0, 0] = (ushort)((block0 >> 5 & 0x3FF) | (Bit(44) << 10) | (Bit(43) << 11));
                        endpoints[0, 1] = (ushort)((block0 >> 15 & 0x3FF) | (Bit(54) << 10) | (Bit(53) << 11));
                        endpoints[0, 2] = (ushort)((block0 >> 25 & 0x3FF) | (Bit(64) << 10) | (Bit(63) << 11));
                        deltas[0, 0] = SignExtend((block0 >> 35) & 0xFF, 8);
                        deltas[0, 1] = SignExtend((block0 >> 45) & 0xFF, 8);
                        deltas[0, 2] = SignExtend((block0 >> 55) & 0xFF, 8);
                    }
                    else if (m == 15)
                    {
                        wBits = 16;
                        endpoints[0, 0] = (ushort)((block0 >> 5 & 0x3FF) | (Bit(44) << 10) | (Bit(43) << 11) | (Bit(42) << 12) | (Bit(41) << 13) | (Bit(40) << 14) | (Bit(39) << 15));
                        endpoints[0, 1] = (ushort)((block0 >> 15 & 0x3FF) | (Bit(54) << 10) | (Bit(53) << 11) | (Bit(52) << 12) | (Bit(51) << 13) | (Bit(50) << 14) | (Bit(49) << 15));
                        endpoints[0, 2] = (ushort)((block0 >> 25 & 0x3FF) | (Bit(64) << 10) | (Bit(63) << 11) | (Bit(62) << 12) | (Bit(61) << 13) | (Bit(60) << 14) | (Bit(59) << 15));
                        deltas[0, 0] = SignExtend((block0 >> 35) & 0xFF, 4);
                        deltas[0, 1] = SignExtend((block0 >> 45) & 0xFF, 4);
                        deltas[0, 2] = SignExtend((block0 >> 55) & 0xFF, 4);
                    }

                    var epm = (ushort)((1 << wBits) - 1);

                    var isTransformed = m is not 3 and not 30;
                    var isRegionOne = m is 3 or 7 or 11 or 15;

                    if (isRegionOne)
                    {
                        ib = block64 >> 1;
                    }
                    else
                    {
                        pb = (byte)(block64 >> 13 & 0x1F);
                        ib = block64 >> 18;
                    }

                    static int Unquantize(int quantized, int precision)
                    {
                        if (precision >= 15)
                        {
                            return quantized;
                        }

                        if (quantized == 0)
                        {
                            return 0;
                        }

                        var precisionMax = (1 << precision) - 1;

                        if (quantized == precisionMax)
                        {
                            return ushort.MaxValue;
                        }

                        var ushortRange = ushort.MaxValue + 1;
                        return (quantized * ushortRange + ushortRange / 2) >> precision;
                    }

                    static ushort FinishUnquantize(int q)
                    {
                        return (ushort)((q * 31) >> 6);
                    }

                    if (isTransformed)
                    {
                        for (var d = 0; d < 3; d++)
                        {
                            for (var e = 0; e < 3; e++)
                            {
                                endpoints[d + 1, e] = (ushort)((endpoints[0, e] + deltas[d, e]) & epm);
                            }
                        }
                    }

                    for (var s = 0; s < 4; s++)
                    {
                        for (var e = 0; e < 3; e++)
                        {
                            endpoints[s, e] = Unquantize(endpoints[s, e], wBits);
                        }
                    }

                    for (var by = 0; by < 4; by++)
                    {
                        for (var bx = 0; bx < 4; bx++)
                        {
                            var pixelIndex = (j * 4 + by) * rowBytes + (i * 4 + bx) * 4;
                            var io = by * 4 + bx;

                            var isAnchor = 0;
                            byte bWeight = 0;
                            byte subset = 0;
                            if (isRegionOne)
                            {
                                isAnchor = (io == 0) ? 1 : 0;
                                bWeight = BPTCWeights4[ib & 0xFu >> isAnchor];
                                ib >>= 4 - isAnchor;
                            }
                            else
                            {
                                subset = (byte)(BPTCPartitionTable2[pb, io] * 2);
                                isAnchor = (io == 0 || io == BPTCAnchorIndices2[pb]) ? 1 : 0;
                                bWeight = BPTCWeights3[ib & 0x7u >> isAnchor];
                                ib >>= 3 - isAnchor;
                            }

                            var aWeight = 64 - bWeight;

                            for (var e = 0; e < 3; e++)
                            {
                                var a = endpoints[subset, e];
                                var b = endpoints[subset + 1, e];

                                var lerped = (ushort)((a * aWeight + b * bWeight) / (float)(1 << 6));
                                lerped = FinishUnquantize(lerped);

                                var floatValue = (float)Unsafe.As<ushort, Half>(ref lerped);

                                data[pixelIndex + 2 - e] = Common.ToClampedLdrColor(floatValue);
                            }

                            data[pixelIndex + 3] = byte.MaxValue;
                        }
                    }
                }
            }
        }

        private static short SignExtend(ulong v, int bits)
        {
            Debug.Assert(bits < 16);

            var signed = checked((short)v);
            var hasSetSignBit = ((v >> (bits - 1)) & 1) == 1;
            var extendedSignBit = -1 << (bits);

            if (hasSetSignBit)
            {
                signed |= (short)extendedSignBit;
            }

            return signed;
        }
    }
}
