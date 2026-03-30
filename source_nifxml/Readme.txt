This XML is the source for the NIF file format specification that I followed when I wrote my library's code.
The original file can be found here: https://github.com/niftools/nifxml/

The version info for this particular copy is as follows:
Version: 0.9.0
Released: 18 Dec 2017


As for why there are multiple copies of the XML here, they all come from the same specification file mentioned above. The different copies have different purposes:

nif_Target.xml
- This is a complete unaltered copy of the NIF specification XML. It indicates which version the current development goal is aiming for. In other words, the repo's code is not currently compatible with this version, but it will be in the future.


nif_Unimplemented.xml
- This is an edited copy of the nif_Target.xml described above. It indicates the parts of the target NIF specification version that have not been implemented yet. The smaller this file is, the less work that still needs to be done to bring the repo code in line with the target version.
