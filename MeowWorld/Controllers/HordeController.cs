using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class HordeController : Controller
    {
        private static readonly Dictionary<string, string> _cats = new Dictionary<string, string>();

        [HttpGet("horde/add/{cat}")]
        public string Add(string cat, string sound)
        {
            _cats[cat] = sound;
            return string.Format("{0} added to the horde!", cat);
        }

        [HttpGet("horde/{cat}")]
        public string Get(string cat)
        {
            if (!_cats.ContainsKey(cat))
                return "Cat not found.";
            return _cats[cat];
        }

        [HttpPatch("horde/{cat}")]
        public string Patch(string cat, [FromBody] string sound)
        {
            if (!_cats.ContainsKey(cat))
                return "Cat not found.";

            _cats[cat] = sound;

            return "Cat updated.";
        }

        [HttpDelete("horde/{cat}")]
        public string Delete(string cat)
        {
            if (!_cats.ContainsKey(cat))
                return "Cat not found.";
            _cats.Remove(cat);
            return "Cat deleted.";
        }

        [HttpPost("horde/{cat}")]
        public string Post(string cat, [FromBody] string sound)
        {
            _cats[cat] = sound;
            return string.Format("{0} added to the horde!", cat);
        }
    }
}
