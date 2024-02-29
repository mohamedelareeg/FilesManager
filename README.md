

The Files Manager is a component of a system designed to handle file management
operations in a web application. This controller specifically handles file
uploading, downloading, and retrieval functionalities.

-------------------------------------------------------------------------------

Features
--------

- Upload files with associated batch and document IDs.
- Retrieve and load files based on a specified path.
- Download files from the server.

-------------------------------------------------------------------------------

Usage
-----

To utilize the Files Manager:

1. Clone the repository:

   git clone https://github.com/mohamedelareeg/FilesManager.git

2. Build the solution using Visual Studio or your preferred IDE.

3. Ensure that the necessary dependencies are installed and configured.

4. Access the FileController endpoints via HTTP requests or integrate them
   into your existing application.

-------------------------------------------------------------------------------

Endpoints
---------

1. **Upload:** `POST /File/Upload`

   - Uploads files to the server.
   - Requires a list of form files, batch ID, and optional document ID.
   - Returns information about the uploaded files.

2. **GetFiles:** `POST /File/GetFiles`

   - Retrieves files based on the provided request object.
   - Requires a request object containing a path.
   - Returns a BatchCRUDViewModel object.

3. **Download:** `GET /File/Download`

   - Downloads files from the server based on the provided subdirectory.
   - Requires a subdirectory path.
   - Returns the requested file(s) as a downloadable file.

-------------------------------------------------------------------------------

Dependencies
------------

- ASP.NET Core
- Microsoft.AspNetCore.Http
- Microsoft.Extensions.Hosting
- Newtonsoft.Json

-------------------------------------------------------------------------------

Contributing
------------

Contributions are welcome! If you'd like to contribute to the Files Manager,
feel free to open a pull request or submit an issue on the GitHub repository.

-------------------------------------------------------------------------------

License
-------

This project is licensed under the MIT License - see the LICENSE file for
details.

-------------------------------------------------------------------------------

Acknowledgments
---------------

- Microsoft.AspNetCore.Hosting - Hosting environment for ASP.NET Core.
- Newtonsoft.Json - JSON serialization and deserialization library for .NET.
