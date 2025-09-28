# BIM Open Geometry

## This is a companion project to [BIM Open Schema](https://github.com/ara3d/bim-open-schema). 

BIM Open Geometry schema for efficiently representing large 3D models that represent the built environment used in 
AECO (Architecture, Engineering, Construction, and Operations).

It is optimized for columnar and tabular data representations such as Apache Parquet, but is   
format agnostic and compatible with different transport mechanisms such as Apache Parquet, JSON, MessagePack, FlatBuffers, and so-on.

BIM Open Geometry is stored in a format that is GPU friendly, and can be quickly and easily loaded into most 3D rendering engines.

# Compared to GLTF

BIM Open Geometry is designed a more narrow set of use cases than GLTF (no textures or animations) and is optimized for BIM models. 
As a result it is much simpler to read and write, needing only a fraction of the code. 

When used with Apache Parquet as the transport mechanism and Brotli compression, it result in files that 1/10<sup>th</sup> the size of a comparable 
GLB. Nearly the size of a Draco compressed file but with more universal support.  

# What is Apache Parquet

Apache Parquet is an open source, column-oriented data file format designed for efficient data storage and retrieval. 

It is very efficient, and can be loaded "as-is" with many analytics tools (e.g. Power BI and Duck DB).

There are efficient open-source libraries for reading and writing Apache files available for multiple programming languages
and platforms.  

# What is the Different Between a Format, Schemas, and Data Models

JSON, XML, Parquet, MessagePack, FlatBuffers, ProtoBuff, STEP, are all examples data formats. 
They can be used to represent arbitrary data in transit or serialized to a storage medium (like disk or RAM).

If an application or service, recieves arbitrary data in one of those formats, it has no way to understand or extract meaning out 
of that data, without some kind of convention in place. 

There convention that we need to establish to be able to allow two applications to communicate has two parts:
- The structure and relationships between the data elements - described by the schema
- The meaning of the data - described by the data model

Sometimes the schema is sufficient that we can derive the data model or vice versa, especially if they are  accompanied by 
documentation. 

Schemas may be described in a formal language. Some example of format languages include:
- XML Schema Definition (.xsd)
- JSON Schema Definition (.jsd)
- Express (.exp)
- Data Definition Language (.ddl)
- Protobuf (.proto)

# How does it compare to IFC 

IFC a set of data models and schemas for BIM data, both geometric and otherwise, formally described in both XSD and Express formats. 

IFC supports multiple transport mechanisms, but is most commonly used with the STEP format.  

IFC is very comprehensive, complex, and inefficient. IFC is not GPU friendly. The geometric representation of IFC elements requires 
powerful libraries to do sophisticated post-processing before it can be converted into a format that can be rendered.   
 
