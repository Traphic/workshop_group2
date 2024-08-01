using Blog.Data.Enums;
using Blog.Data.Models;

namespace Blog.Data.Data
{
    public static class SeedData
    {
        public static List<Post> GetPosts()
        {
            return
            [
                new Post { 
                    Id = 1,
                    Title = "Ten facts about cats",
                    Content = CatFacts(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "CatOwner",
                    Image = "cat.jpg"
                },
                new Post {
                    Id = 2,
                    Title = "Discovering Blazor: The Future of Web Development",
                    Content = BlazorArticle(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    Image = "Blazor.png"
                },
                new Post
                {
                    Id = 3,
                    Title = "Breakthrough in Medicine: The Promise of mRNA Vaccines",
                    Content = MedicineNewsArticle(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Doc",
                    Image = "medicine.jpg"
                },
                new Post
                {
                    Id = 4,
                    Title = "Exploring What's New in .NET 8",
                    Content = DotNetNewsArticle(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin",
                    Image = "dotNet.png"
                },
                new Post
                {
                    Id = 5,
                    Title = "Unveiling Mysteries from the Ocean Depths: Recent Discoveries",
                    Content = OceanNewsArticle(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Admin"
                }
            ];
        }

        public static List<Category> GetCategories()
        {
            return
            [
                new Category { 
                    Id = 1,
                    Name = "Animals"
                },
                new Category {
                    Id = 2,
                    Name = "Cats" 
                },
                new Category {
                    Id = 3,
                    Name = "IT" 
                },
                new Category {
                    Id = 4,
                    Name = "Medicine" 
                },
            ];
        }

        public static List<PostCategory> GetPostCategories()
        {
            return
            [
                new PostCategory
                {
                    CategoryId = 1,
                    PostId = 1
                },
                new PostCategory
                {
                    CategoryId = 2,
                    PostId = 1
                },
                new PostCategory
                {
                    CategoryId = 3,
                    PostId = 2
                },
                new PostCategory
                {
                    CategoryId = 3,
                    PostId = 4
                },
                new PostCategory
                {
                    CategoryId = 4,
                    PostId = 3
                }
            ];
        }

        public static ApplicationUser GetAdminUser()
        {
            return new ApplicationUser { Username = "admin", Email = "admin@mail.com", Password = BCrypt.Net.BCrypt.HashPassword("admin"), Role = Role.Admin };
        }

        private static string CatFacts()
        {
            return "Ancient Reverence: Cats were highly revered in ancient Egypt." +
                "They were considered sacred animals and were associated with the goddess Bastet, who was often depicted in the form of a lioness or as a woman with a lioness head." +
                "Killing a cat, even accidentally, was considered a serious crime punishable by death.\n" +
                "Nocturnal Hunters: Cats are crepuscular creatures, meaning they are most active during dawn and dusk. This behavior is believed to be a result of their wild ancestors' hunting patterns, which were more successful during twilight hours.\n" +
                "Whisker Wonders: A cat's whiskers are highly sensitive tactile hairs called vibrissae. " +
                "They are deeply embedded in the cat's body and are connected to nerves, providing them with detailed information about their surroundings." +
                " Whiskers are approximately as wide as a cat's body, helping them navigate through tight spaces.\n" +
                "Purring Mystery: Cats are the only known animals that purr both when inhaling and exhaling." +
                " While the exact reason behind why cats purr is not fully understood, it is commonly believed to be a form of self-healing and communication." +
                " Cats often purr when they are content, but they may also purr when they are in pain or distress.\n" +
                "Superior Jumpers: Cats are incredible jumpers due to their powerful hind leg muscles and flexible backbones." +
                " They can jump up to six times their body length in a single bound, making them adept hunters and agile climbers.\n" +
                "Communication Styles: Cats communicate with each other and with humans through a variety of vocalizations, including meowing, purring, hissing, and chirping." +
                " Interestingly, cats rarely meow at other cats—they reserve this form of communication specifically for humans.\n" +
                "Territorial Instincts: Cats are territorial animals that mark their territory with scent glands located on their faces, paws, and tails." +
                " They often rub against objects and people to leave their scent and claim ownership.\n" +
                "Unique Personalities: Each cat has a distinct personality." +
                " They can be playful, independent, affectionate, or reserved depending on their genetics and early socialization experiences. Some cats are more vocal and demanding of attention, while others are more aloof and prefer solitude.\n" +
                "Incredible Adaptability: Cats are highly adaptable animals. They can thrive in a variety of environments, from busy city apartments to rural farms. Their natural instincts for hunting and self-preservation make them successful companions in diverse settings.\n" +
                "Life Expectancy: The average lifespan of an indoor cat is around 15 years, but many cats live well into their late teens or early twenties with proper care. Factors such as diet, exercise, and regular veterinary check-ups can significantly impact a cat's longevity.\n" +
                "These fascinating facts underscore the unique and captivating nature of cats, making them beloved companions and intriguing creatures to observe and learn about.";
        }

        private static string BlazorArticle()
        {
            return "In the rapidly evolving landscape of web development, Blazor emerges as a groundbreaking technology that promises to revolutionize how we build interactive web applications." +
                " Developed by Microsoft, Blazor combines the power of C# and .NET with modern web standards to enable developers to create dynamic, single-page applications entirely in C# without relying on JavaScript.\n\n" +
                "What is Blazor?\n\n" +
                "Blazor is an open-source web framework that allows developers to build interactive web UIs using C# instead of JavaScript." +
                " It leverages the WebAssembly standard to run .NET code directly in the browser, providing a rich and seamless development experience." +
                " With Blazor, developers can write client-side code in C#, share code between the client and server, and create responsive, high-performance web applications.\n\n" +
                "Key Features of Blazor\n\n" +
                "Single-page Applications (SPAs): Blazor enables the development of SPAs where UI updates and interactions occur dynamically without full page reloads." +
                " This leads to smoother user experiences akin to native applications.\n" +
                "Component-Based Architecture: Blazor adopts a component-based architecture similar to popular frontend frameworks like React and Vue.js." +
                " Developers can create reusable UI components with rich functionalities.\n" +
                "Full Stack Development with .NET: Blazor supports full stack development by allowing developers to write backend logic and frontend UI components using C# and .NET." +
                " This cohesive approach streamlines development and reduces technology stack complexities.\n" +
                "Code Sharing: Blazor facilitates code sharing between client-side and server-side applications, reducing redundancy and enhancing maintainability." +
                " Developers can write business logic once and use it across different layers of the application.\n" +
                "Integration with Existing .NET Ecosystem: Blazor seamlessly integrates with the existing .NET ecosystem, including libraries, tooling, and frameworks." +
                " Developers can leverage their knowledge of C# and .NET to build modern web applications efficiently.\n\n" +
                "Benefits of Using Blazor\n\n" +
                "Unified Development Environment: Developers can utilize their existing skills in C# and .NET to build both frontend and backend components, leading to increased productivity and reduced learning curve.\n" +
                "Performance: Blazor applications benefit from the efficiency of compiled .NET code, resulting in fast load times, smooth interactions, and responsive user interfaces.\n" +
                "Cross-Platform Compatibility: Blazor supports cross-platform development, allowing applications to run seamlessly on different devices and browsers without sacrificing performance or functionality.\n" +
                "Getting Started with Blazor\n\n" +
                "To start developing with Blazor, developers can install the necessary tooling and templates using .NET SDK." +
                " Visual Studio and Visual Studio Code provide excellent support for Blazor development, offering project templates, debugging tools, and extensions for enhanced productivity." +
                "\n\nIn conclusion, Blazor represents a significant leap forward in web development by empowering developers to create modern, high-performance web applications using familiar C# and .NET technologies." +
                " Whether you're a seasoned .NET developer or exploring new frontend frameworks, Blazor offers a compelling solution for building robust and interactive web experiences.";
        }

        private static string MedicineNewsArticle()
        {
            return "One of the most groundbreaking advancements in medicine is the development of mRNA vaccines, exemplified by the COVID-19 vaccines." +
                "Unlike traditional vaccines that use weakened or inactivated viruses, mRNA vaccines teach cells how to make a protein that triggers an immune response." +
                "This technology not only enabled the rapid creation of effective COVID-19 vaccines but also holds potential for combating other infectious diseases and even cancer." +
                "mRNA vaccines represent a paradigm shift in vaccine development, offering new hope for global health challenges.";
        }

        private static string DotNetNewsArticle()
        {
            return "The release of .NET 8 brings a host of exciting features and enhancements for developers. Here are some key highlights:\n\n" +
                "Hot Reload: .NET 8 introduces Hot Reload for editing code during runtime without losing application state." +
                " This boosts developer productivity by allowing real-time code changes.\n" +
                "Nullable Reference Types: Building on previous versions, .NET 8 enhances support for nullable reference types, helping developers write safer and more reliable code by eliminating null-related runtime errors.\n" +
                "Records: Records provide a concise syntax for declaring immutable data types with value-based equality. This simplifies data modeling and enhances code readability.\n" +
                ".NET MAUI: The evolution of Xamarin.Forms, .NET MAUI (Multi-platform App UI) in .NET 8 enables developers to build cross-platform applications for iOS, Android, macOS, and Windows using a single codebase.\n" +
                "Performance Improvements: .NET 8 includes optimizations to enhance performance, such as faster JSON serialization, improved garbage collection, and better runtime execution.\n" +
                "Improvements to C# 10: .NET 8 integrates with C# 10, introducing new language features like global using directives, file-scoped namespaces, and interpolated string handlers.\n" +
                "Enhanced Azure Integration: .NET 8 offers improved integration with Azure services, including enhanced tooling for Azure Functions, Azure Storage, and Azure Cosmos DB.\n" +
                ".NET Interactive: .NET 8 expands support for interactive computing with .NET Interactive notebooks, enabling developers to create and share interactive documents combining code, visualizations, and narrative text.\n" +
                "These features collectively empower developers to build modern, high-performance applications with improved productivity and efficiency using the latest advancements in the .NET ecosystem.";
        }

        private static string OceanNewsArticle()
        {
            return "In the vast and unexplored realms of the ocean, scientists continue to make astonishing discoveries that shed light on the mysteries of marine life and underwater ecosystems." +
                "One of the most recent and intriguing findings involves the identification of deep-sea creatures and ecosystems previously unknown to science.\n\n" +
                "In a groundbreaking expedition conducted just months ago, researchers aboard a specialized deep-sea exploration vessel uncovered a wealth of new species and fascinating phenomena." +
                "Among the most notable discoveries was the identification of a previously undiscovered species of bioluminescent jellyfish, emitting an otherworldly glow deep beneath the ocean's surface." +
                " This finding not only adds to our understanding of marine biodiversity but also highlights the incredible adaptations that allow life to thrive in extreme environments.\n\n" +
                "Moreover, explorers stumbled upon a series of hydrothermal vents teeming with unique microbial communities, suggesting the presence of complex ecosystems fueled by geothermal energy." +
                " These vents, located in the darkest depths of the ocean floor, provide valuable insights into how life can thrive in the absence of sunlight, relying instead on chemical processes.\n\n" +
                "In addition to biological discoveries, researchers made significant strides in mapping and understanding underwater geological formations." +
                " High-resolution sonar imaging revealed intricate seafloor landscapes, including underwater mountains, deep-sea canyons, and ancient volcanic remnants. " +
                "These geological features not only shape ocean currents and habitats but also hold clues to Earth's dynamic geological history.\n\n" +
                "The expedition's findings underscore the importance of continued exploration and conservation efforts in our oceans." +
                " Despite covering more than 70% of the Earth's surface, much of the ocean remains uncharted and unexplored." +
                " Each discovery unveils a new chapter in the ongoing story of our planet's biodiversity and geological evolution.\n\n" +
                "As scientists analyze samples and data collected during the expedition, anticipation builds for further revelations and insights into the ocean's hidden wonders." +
                " These discoveries not only deepen our scientific knowledge but also inspire awe and appreciation for the vast and enigmatic world beneath the waves. " +
                "They serve as a reminder of the urgent need to protect and preserve our oceans for future generations, ensuring that these incredible ecosystems and their inhabitants continue to thrive in the face of environmental challenges.";
        }
    }
}
