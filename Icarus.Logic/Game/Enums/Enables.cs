using System;

namespace Icarus.Logic.Game.Enums
{
    [Flags]
    public enum Enables : uint
    {
        Doodads = 0x1,
        Chunks = 0x2,
        Lod = 0x4,
        Texture = 0x8,
        Sky = 0x10,
        Culling = 0x20,
        Shadow = 0x40,
        Collision = 0x80,
        MapObjs = 0x100,
        MapObjLight = 0x200,
        VertexLight = 0x400,
        MapObjTex = 0x800,
        Portals = 0x1000,
        PortalVis = 0x2000,
        NoFullAlpha = 0x4000,
        NoAnimation = 0x8000,
        DebugBSP = 0x10000,
        CrappyBatches = 0x20000,
        ZoneBounds = 0x40000,
        MapObjBSP = 0x80000,
        DetailDoodads = 0x100000,
        ShowQuery = 0x200000,
        AABoxes = 0x400000,
        Trilinear = 0x800000,
        Water = 0x1000000,
        Particulates = 0x2000000,
        LowDetail = 0x4000000,
        Specular = 0x8000000,
        PixelShaders = 0x10000000,
        ShowTris = 0x20000000,
        ShowNormals = 0x40000000,
        Anisotropic = 0x80000000,
    }
}