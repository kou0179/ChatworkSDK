#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        // TODO: 実装する Content-Type: multipart/form-dataのためbaseを使わない
        public Task<IEnumerable<PostRoomFilesResponse>> QueryAsync(PostRoomFileQuery query) =>
            throw new NotImplementedException("Will be implemented in the future");
    }

    internal class PostRoomFileQuery
    {

        private int _roomId;

        public PostRoomFileQuery(int roomId, byte[] file, string filename, string contentType)
        {
            _roomId = roomId;
            File = file;
            Filename = filename;
            ContentType = contentType;
        }

        public byte[] File { get; private set; }
        public string Filename { get; private set; }
        public string ContentType { get; private set; }
        public string? Message { get; private set; }
        public string Path => $"/rooms/{_roomId}/files";

    }

    internal class PostRoomFilesResponse
    {
        public int file_id { get; set; }
    }
}
