using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieApp.Models
{
    public class DBInitializer
    {
        public static void InitializeDb(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                MovieAppContext context = serviceScope.ServiceProvider.GetService<MovieAppContext>();


                context.Database.Migrate();

                if (context.Movies.Any() == false)
                {
                    context.Movies.AddRange(

                        new Movie() { Title = "X-Men: The Last Stand", Rating = (float)(6.7), ReleaseYear = 2006, Image = "movie1.jpg",Description= "X-Men: The Last Stand is a 2006 superhero film, based on the X-Men superhero team introduced in Marvel Comics. It is the sequel to 2003's X2, the third installment in the X-Men film series, and the third film of the X-Men quadrilogy. The film was directed by Brett Ratner, written by Simon Kinberg and Zak Penn, and features an ensemble cast, including Hugh Jackman, Halle Berry, Ian McKellen, Famke Janssen, Anna Paquin, Kelsey Grammer, James Marsden, Rebecca Romijn, Shawn Ashmore, Aaron Stanford, Vinnie Jones, and Patrick Stewart. The film's script is loosely based on two X-Men comic book story arcs: The Dark Phoenix Saga by writer Chris Claremont and artist John Byrne, and Gifted by writer Joss Whedon and artist John Cassaday, with a plot that revolves around a mutant cure that causes serious repercussions among mutants and humans, and on the resurrection of Jean Grey." },
                        new Movie() { Title = "SPIDER MAN 2", Rating = (float)(7.3), ReleaseYear = 2004, Image = "movie2.jpg" ,Description= "Spider-Man 2 is a 2004 American superhero film directed by Sam Raimi and written by Alvin Sargent from a story by Alfred Gough, Miles Millar and Michael Chabon. A sequel to the 2002 film Spider-Man, it is the second installment in the Spider-Man trilogy based on the fictional Marvel Comics character of the same name. Tobey Maguire, Kirsten Dunst, James Franco, Rosemary Harris, and J. K. Simmons reprise their respective roles as Peter Parker / Spider-Man, Mary Jane Watson, Harry Osborn, Aunt May, and J. Jonah Jameson, while Alfred Molina and Donna Murphy join the cast as Otto Octavius / Doctor Octopus and Rosalie Octavius." },
                        new Movie() { Title = "SPIDER MAN 3", Rating = (float)(6.2), ReleaseYear = 2007, Image = "movie3.jpg",Description= "Spider-Man 3 is a 2007 American superhero film based on the fictional Marvel Comics character Spider-Man. It was directed by Sam Raimi from a screenplay by Raimi, his older brother Ivan, and Alvin Sargent. It is the third and final installment in Raimi's original Spider-Man film trilogy, following Spider-Man (2002) and Spider-Man 2 (2004). The film stars Tobey Maguire, Kirsten Dunst, James Franco, Thomas Haden Church, Topher Grace, Bryce Dallas Howard, Rosemary Harris, Cliff Robertson, J. K. Simmons, and James Cromwell. It is the highest grossing Spider-Man film ever made. Following the events of Spider-Man 2, Peter Parker has become a cultural phenomenon as Spider-Man, while Mary Jane Watson continues her Broadway career. Harry Osborn still seeks vengeance for his father's death, and an escaped Flint Marko falls into a particle accelerator and is transformed into a shape-shifting sand manipulator. An extraterrestrial symbiote crashes to Earth and bonds with Peter, influencing his behavior for the worse." },
                        new Movie() { Title = "VALKYRIE", Rating = (float)(7.1), ReleaseYear = 2008, Image = "movie4.jpg",Description= "Valkyrie is a 2008 historical thriller film set in Nazi Germany during World War II. The film depicts the 20 July plot in 1944 by German army officers to assassinate Adolf Hitler and to use the Operation Valkyrie national emergency plan to take control of the country. Valkyrie was directed by Bryan Singer for the American studio United Artists, and the film stars Tom Cruise as Colonel Claus von Stauffenberg, one of the key plotters. The cast included Kenneth Branagh, Bill Nighy, Eddie Izzard, Terence Stamp, and Tom Wilkinson." },
                        new Movie() { Title = "GLADIATOR", Rating = (float)(8.5), ReleaseYear = 2000, Image = "movie5.jpg",Description= "Gladiator is a 2000 epic historical drama film directed by Ridley Scott and written by David Franzoni, John Logan, and William Nicholson. The film was jointly produced and released by DreamWorks Pictures and Universal Pictures. It stars Russell Crowe, Joaquin Phoenix, Connie Nielsen, Ralf Möller, Oliver Reed (in his final role), Djimon Hounsou, Derek Jacobi, John Shrapnel, and Richard Harris. Crowe portrays Hispano-Roman general Maximus Decimus Meridius, who is betrayed when Commodus, the ambitious son of Emperor Marcus Aurelius, murders his father and seizes the throne. Reduced to slavery, Maximus rises through the ranks of the gladiatorial arena to avenge the murders of his family and his emperor" },
                        new Movie() { Title = "ICE AGE", Rating = (float)(7.5), ReleaseYear = 2002, Image = "movie6.jpg",Description= "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "TRANSFORMERS", Rating = (float)(7.1), ReleaseYear = 2007, Image = "movie7.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "MAGNETO", Rating = (float)(7.1), ReleaseYear = 1998, Image = "movie8.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "KUNG FU PANDA", Rating = (float)(7.6), ReleaseYear = 2008, Image = "movie9.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "EAGLE EYE", Rating = (float)(6.6), ReleaseYear = 2008, Image = "movie10.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "NARNIA", Rating = (float)(6.5), ReleaseYear = 2008, Image = "movie11.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "ANGELS & DEMONS", Rating = (float)(6.7), ReleaseYear = 2009, Image = "movie12.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "HOUSE", Rating = (float)(4.7), ReleaseYear = 2008, Image = "movie13.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "VACANCY", Rating = (float)(6.2), ReleaseYear = 2007, Image = "movie14.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "MIRRORS", Rating = (float)(6.2), ReleaseYear = 2008, Image = "movie15.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "THE KINGDOM", Rating = (float)(7.0), ReleaseYear = 2007, Image = "movie16.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "MOTIVES", Rating = (float)(5.3), ReleaseYear = 2004, Image = "movie17.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" },
                        new Movie() { Title = "THE PRESTIGE", Rating = (float)(8.5), ReleaseYear = 2006, Image = "movie18.jpg", Description = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur" }

                    );
                    context.SaveChanges();
                }

                if (context.Categories.Any() == false)
                {
                    context.Categories.AddRange(
                    new Category() { CategoryName= "Action" },
                    new Category() { CategoryName= "Animation" },
                    new Category() { CategoryName= "Biography" },
                    new Category() { CategoryName= "Comedy" },
                    new Category() { CategoryName= "Crime" },
                    new Category() { CategoryName= "Documentary" },
                    new Category() { CategoryName= "Drama" },
                    new Category() { CategoryName= "Fantasy" },
                    new Category() { CategoryName= "Horror" },
                    new Category() { CategoryName= "Mystery" },
                    new Category() { CategoryName= "Romance" },
                    new Category() { CategoryName= "Sci-Fi" },
                    new Category() { CategoryName= "Thriller" },
                    new Category() { CategoryName= "Western" }
                    
                    );
                    context.SaveChanges();

                }

                if (context.MovieCategories.Any() == false)
                {
                    context.MovieCategories.AddRange(
                    new MovieCategory() { MovieId = 1, CategoryId = 12 },
                    new MovieCategory() { MovieId = 1, CategoryId = 1 },
                    new MovieCategory() { MovieId = 2, CategoryId = 1 },
                    new MovieCategory() { MovieId = 2, CategoryId = 7 },
                    new MovieCategory() { MovieId = 3, CategoryId = 9 },
                    new MovieCategory() { MovieId = 3, CategoryId = 13 },
                    new MovieCategory() { MovieId = 4, CategoryId = 5},
                    new MovieCategory() { MovieId = 4, CategoryId = 9 },
                    new MovieCategory() { MovieId = 4, CategoryId = 13 },
                    new MovieCategory() { MovieId = 5, CategoryId = 7 },
                    new MovieCategory() { MovieId = 5, CategoryId = 9 },
                    new MovieCategory() { MovieId = 5, CategoryId = 13 },
                    new MovieCategory() { MovieId = 6, CategoryId = 10 },
                    new MovieCategory() { MovieId = 6, CategoryId = 13 },
                    new MovieCategory() { MovieId = 7, CategoryId = 1 },
                    new MovieCategory() { MovieId = 7, CategoryId = 8 },
                    new MovieCategory() { MovieId = 8, CategoryId = 1 },
                    new MovieCategory() { MovieId = 8, CategoryId = 13 },
                    new MovieCategory() { MovieId = 9, CategoryId = 1 },
                    new MovieCategory() { MovieId = 9, CategoryId = 2 },
                    new MovieCategory() { MovieId = 10, CategoryId = 7 },
                    new MovieCategory() { MovieId = 11, CategoryId = 1 },
                    new MovieCategory() { MovieId = 11, CategoryId = 12 },
                    new MovieCategory() { MovieId = 11, CategoryId = 13 },
                    new MovieCategory() { MovieId = 12, CategoryId = 1 },
                    new MovieCategory() { MovieId = 12, CategoryId = 2 },
                    new MovieCategory() { MovieId = 12, CategoryId = 4 },
                    new MovieCategory() { MovieId = 12, CategoryId = 8 },
                    new MovieCategory() { MovieId = 13, CategoryId = 7 },
                    new MovieCategory() { MovieId = 14, CategoryId = 7 },
                    new MovieCategory() { MovieId = 14, CategoryId = 13 },
                    new MovieCategory() { MovieId = 15, CategoryId = 1 },
                    new MovieCategory() { MovieId = 15, CategoryId = 12 },
                    new MovieCategory() { MovieId = 16, CategoryId = 1 },
                    new MovieCategory() { MovieId = 16, CategoryId = 12 },
                    new MovieCategory() { MovieId = 17, CategoryId = 7 },
                    new MovieCategory() { MovieId = 17, CategoryId = 13 },
                    new MovieCategory() { MovieId = 18, CategoryId = 12 },
                    new MovieCategory() { MovieId = 18, CategoryId = 13 }
                    );
                }

                if(context.Admins.Any()== false)
                {
                    context.Admins.AddRange(
                        new Admin() { Username="Yahyagngrr", Password= 123 },
                        new Admin() { Username ="BesteDeniz", Password= 123 },
                        new Admin() { Username ="Hibrahim", Password= 123 }
                   
                        );
                    context.SaveChanges();
                }


            }
        }
    }
}
