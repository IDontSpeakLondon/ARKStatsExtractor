﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace ARKBreedingStats.species
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ColorRegion
    {
        [JsonProperty]
        public string name;
        /// <summary>
        /// List of natural occuring color names.
        /// </summary>
        [JsonProperty]
        public List<string> colors = new List<string>();
        /// <summary>
        /// List of natural occuring ARKColors.
        /// </summary>
        public List<ARKColor> naturalColors;

        public ColorRegion()
        {
            name = Loc.s("unknown");
        }

        /// <summary>
        /// Sets the ARKColor objects
        /// </summary>
        internal void Initialize(ARKColors arkColors)
        {
            naturalColors = new List<ARKColor>();
            if (colors == null) return;
            foreach (var c in colors)
            {
                ARKColor cl = arkColors.ByName(c);
                if (cl.hash != 0 && !naturalColors.Contains(cl))
                    naturalColors.Add(cl);
            }
        }
    }
}
