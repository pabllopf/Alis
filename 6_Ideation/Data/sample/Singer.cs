using System;
        using System.Runtime.InteropServices;
        
        namespace Alis.Core.Aspect.Data.Sample
        {
            [Serializable]
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public partial class Singer(
                string name,
                string genre,
                int age,
                string country,
                bool isActive,
                DateTime debutDate,
                Guid singerId
            )
            {
                public Singer() : this(
                    string.Empty, string.Empty, 0, string.Empty,
                    false, default, Guid.Empty)
                {
                }
        
                public string Name { get; set; } = name;
                public string Genre { get; set; } = genre;
                public int Age { get; set; } = age;
                public string Country { get; set; } = country;
                public bool IsActive { get; set; } = isActive;
                public DateTime DebutDate { get; set; } = debutDate;
                public Guid SingerId { get; set; } = singerId;
            }
        }