using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test_debug.Controllers
{
    [Route("home")]
    public class HomeController
    {
        [HttpPost("upload")]
        public async Task<ActionResult> Index([FromForm] TestModel test)
        {
            return new JsonResult(new { Gotit = "gitit" });
        }
    }

    public class TestModel
    {
        public string Name { get; set; }

        public StreamType StreamType { get; set; }

        public IFormFile Thumbnail { get; set; }

    }

    [DataContract]
    public enum StreamType
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        RawVideo = 1,

        [EnumMember]
        Panoramic = 2,

        /// <summary>
        /// This is a CV generated stream that follows the action during a game based on the other raw video streams.
        /// </summary>
        [EnumMember]
        Tactical = 3,

        /// <summary>
        /// A per-frame bit-array of where the edges are in the image.
        /// </summary>
        /// <remarks>
        /// This is a data only stream and does not contain any media streams.
        /// </remarks>
        [EnumMember]
        EdgeData = 4,

        [EnumMember]
        PanoramicDebug = 5,

        [EnumMember]
        TacticalDebug = 6,
    }
}