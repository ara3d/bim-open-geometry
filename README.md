# BIM Open Geometry

This is a companion project to [BIM Open Schema](https://github.com/ara3d/bim-open-schema). 

## About BIM Open Geometry

BIM Open Geometry schema for efficiently representing large 3D models that represent the built environment used in 
AECO (Architecture, Engineering, Construction, and Operations).

It is optimized for columnar and tabular data representations such as Apache Parquet, but is   
format agnostic and compatible with different transport mechanisms such as Apache Parquet, JSON, MessagePack, FlatBuffers, and so-on.

BIM Open Geometry is stored in a format that is GPU friendly, and can be quickly and easily loaded into most 3D rendering engines.

## What is Apache Parquet

Apache Parquet is an open source, column-oriented data file format designed for efficient data storage and retrieval. 
It is very efficient, and can be loaded "as-is" with many analytics tools (e.g. Power BI and Duck DB).

There are efficient open-source libraries for reading and writing Apache files available for multiple programming languages
and platforms.

Apache Parquet is our recommended serialization and storage format for BIM Open Geometry. 

## What is the Different Between a Format, Schema, and Data Model

JSON, XML, Parquet, MessagePack, FlatBuffers, ProtoBuff, STEP, are all examples of data formats. 
They can be used to represent arbitrary data in transit or serialized to a storage medium (like disk or RAM).

If an application or service, recieves arbitrary data in one of those formats, there is no general way to easily understand or extract meaning out 
of that data, without some kind of convention in place. 

There convention that we need to establish to be able to allow two applications to communicate usually has two parts:
- **The schema** - defines the structure and relationships between the data elements, used for validation 
- **The data model** - The meaning of the data

When accompanied with documentation the schema is often sufficient that we can derive the data model and vice versa. 

Schemas may be described in a formal language. Some example of these languages include:
- [XML Schema Definition](https://en.wikipedia.org/wiki/XML_Schema_(W3C)) (.xsd)
- [JSON Schema](https://json-schema.org/) (.jsd)
- [Express](https://en.wikipedia.org/wiki/EXPRESS_(data_modeling_language)) (.exp)
- [Data Definition Language](https://en.wikipedia.org/wiki/Data_definition_language) (.ddl)
- [Protobuf](https://en.wikipedia.org/wiki/Protocol_Buffers) (.proto)
- [Flat Buffers Interface Definition Language](https://flatbuffers.dev/schema/) (.idl)

## Comparison to IFC 

IFC a set of data models and schemas for BIM data, both geometric and otherwise, formally described in both XSD and Express formats. 

IFC supports multiple transport mechanisms, but is most commonly used with the STEP format.  

IFC is very comprehensive, complex, and inefficient. IFC is not GPU friendly. The geometric representation of IFC elements requires 
powerful libraries to do sophisticated post-processing before it can be converted into a format that can be rendered.   

BIM Open Geometry represents the geometric data in a GPU friendly format that can be loaded onto the GPU and rendered with almost 
no pre-processing, making it several orders of magnitude faster to make changes and re-render.   

BIM Open Geometry works in tandem with BIM Open Schema (using shared Entity IDs) to associate BIM meta-data. 

## Comparison to GLTF

BIM Open Geometry and GLTF both can be used to define large complex AEC scenes. 

BIM Open Geometry is designed a more narrow set of use cases than GLTF (no textures or animations) and is optimized for BIM models. 
As a result it is much simpler to read and write, needing only a fraction of the code. 

When used with Apache Parquet as the transport mechanism combined with Brotli compression, BIM Open Geometry result in files that 1/10<sup>th</sup> the size of a comparable 
GLB. Nearly the size of a Draco compressed file but with more universal support. 

## Other BIM Geometry Formats

Here are several related open formats that are used in the industry to transport the 3D geometry large AEC and BIM models.  

- [Fragments](https://github.com/ThatOpen/engine_fragment)
- [Collada](https://en.wikipedia.org/wiki/COLLADA) 
- [dotbim (.BIM)](https://dotbim.net/)
- [Universal Scene Description (.USD)](https://en.wikipedia.org/wiki/Universal_Scene_Description)
- [IFC5 - under development](https://github.com/buildingSMART/IFC5-development)
- [Xeokit (.XKT)](https://github.com/xeokit/xeokit-sdk/wiki/XKT-Format-V4)
- [FBX](https://en.wikipedia.org/wiki/FBX) - technically not open, but the SDK is free
- [Rhino (.3DM)](https://en.wikipedia.org/wiki/Rhinoceros_3D)
- [Wavefront (.OBJ)](https://en.wikipedia.org/wiki/Wavefront_.obj_file)
- [Stereolithography (.STL)](https://en.wikipedia.org/wiki/STL_(file_format))
  
## Roadmap

We are working hard on developing new tools, libraries, tests, and benchmarks. 
 
