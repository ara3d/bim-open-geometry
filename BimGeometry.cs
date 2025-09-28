namespace Ara3D.BimOpenGeometry;

/// <summary>
/// A columnar representation of the 3D representation (geometry and appearance) for large Building Information Models (BIM).
///
/// This 3D format is optimized for representing complex scenes used in AEC (Architecture, Engineering, and Construction) industry
/// to represent the built environment. 
///
/// It is a collection of meshes, materials, transforms, and elements. 
///
/// Coordinates: Z-Up, right-handed.
/// Units: meters.
/// Indices: Local (per-mesh).
///
/// When stored in a columnar format like parquet, the columns are grouped in the following tables:
/// - Element
/// - Vertex
/// - Index
/// - Material
/// - Mesh
/// - Transform
/// </summary>
public class BimGeometry
{
    //==
    // Element Table
    //
    // An element consists of a mesh, material, transform associated with a specific entity 
    // An entity may have multiple elements.
    // Meshes, materials, and transforms may all be shared to reduce repetition 

    // The index of the associated entity 
    public int[] ElementEntityIndex { get; set; } = [];

    // Index of the material associated with this element
    public int[] ElementMaterialIndex { get; set; } = [];

    // Index of the mesh associated with this element
    public int[] ElementMeshIndex { get; set; } = [];

    // Index of the transform associated with this element
    public int[] ElementTransformIndex { get; set; } = [];

    //==
    // Vertex Table

    // X position of each vertex
    public float[] VertexX { get; set; } = [];
    
    // Y position of each vertex
    public float[] VertexY { get; set; } = [];
    
    // Z position of each vertex
    public float[] VertexZ { get; set; } = [];

    //==
    // Index Table

    // Local face-corner indices: needs to add the appropriate mesh vertex offset  
    public int[] IndexBuffer { get; set; } = [];
    
    //==
    // Mesh Table 
    
    // The offset into the vertex buffer where each mesh starts 
    public int[] MeshVertexOffset { get; set; } = [];
    
    // The offset into the index buffer where each index starts.
    public int[] MeshIndexOffset { get; set; } = [];

    //==
    // Material Table 
    // Bytes represent value from 0 to 1 

    public byte[] MaterialRed { get; set; } = [];
    public byte[] MaterialGreen { get; set; } = [];
    public byte[] MaterialBlue { get; set; } = [];
    public byte[] MaterialAlpha { get; set; } = [];
    public byte[] MaterialRoughness { get; set; } = [];
    public byte[] MaterialMetallic { get; set; } = [];
    
    //==
    // Transform Table.
    // Transform Matrix = Translation Matrix * Rotation Matrix * Scaling Matrix
    // Note: mirrored objects occur when the product of the scale component is negative 

    // Translation
    public float[] TransformTX { get; set; } = [];
    public float[] TransformTY { get; set; } = [];
    public float[] TransformTZ { get; set; } = [];
    
    // Quaternion rotation
    public float[] TransformQX { get; set; } = [];
    public float[] TransformQY { get; set; } = [];
    public float[] TransformQZ { get; set; } = [];
    public float[] TransformQW { get; set; } = [];

    // Scaling 
    public float[] TransformSX { get; set; } = [];
    public float[] TransformSY { get; set; } = [];
    public float[] TransformSZ { get; set; } = [];
}