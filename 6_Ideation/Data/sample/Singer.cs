using System;
        using System.Runtime.InteropServices;
        
        namespace Alis.Core.Aspect.Data.Sample
        {
            /// <summary>
            /// The singer class
            /// </summary>
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
                /// <summary>
                /// Initializes a new instance of the <see cref="Singer"/> class
                /// </summary>
                public Singer() : this(
                    string.Empty, string.Empty, 0, string.Empty,
                    false, default, Guid.Empty)
                {
                }
        
                /// <summary>
                /// Gets or sets the value of the name
                /// </summary>
                public string Name { get; set; } = name;
                /// <summary>
                /// Gets or sets the value of the genre
                /// </summary>
                public string Genre { get; set; } = genre;
                /// <summary>
                /// Gets or sets the value of the age
                /// </summary>
                public int Age { get; set; } = age;
                /// <summary>
                /// Gets or sets the value of the country
                /// </summary>
                public string Country { get; set; } = country;
                /// <summary>
                /// Gets or sets the value of the is active
                /// </summary>
                public bool IsActive { get; set; } = isActive;
                /// <summary>
                /// Gets or sets the value of the debut date
                /// </summary>
                public DateTime DebutDate { get; set; } = debutDate;
                /// <summary>
                /// Gets or sets the value of the singer id
                /// </summary>
                public Guid SingerId { get; set; } = singerId;
            }
        }