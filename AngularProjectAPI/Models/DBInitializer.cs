using AngularProjectAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(NewsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Roles.AddRange(
              new Role { Name = "User" },
              new Role { Name = "Journalist" },
              new Role { Name = "Admin" });
            context.SaveChanges();

            context.Users.AddRange(
                new User { RoleID = 1, Username = "test", Password = "test", FirstName = "Test", LastName = "Test", Email = "test.test@thomasmore.be" }
                );
            context.SaveChanges();

            context.Tags.AddRange(
                new Tag { Name = "Sport" },
                new Tag { Name = "Film" },
                new Tag { Name = "Reizen" },
                new Tag { Name = "Games" }
                );
            context.SaveChanges();

            context.ArticleStatuses.AddRange(
                new ArticleStatus { Name = "Draft" },
                new ArticleStatus { Name = "To review" },
                new ArticleStatus { Name = "Published" }
                );
            context.SaveChanges();

            /*context.Articles.AddRange(
                new Article { UserID = 1, Title = "Messi verlaat FC Barçelona", SubTitle = "Messi stuurde een fax met de boodschap dat hij wilt vertrekken.", ArticleStatusID = 1, TagID = 1, Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus consequat non justo dignissim varius. Morbi finibus magna non neque bibendum efficitur. Aliquam eu auctor sem, ut mollis erat. Donec ornare dolor ex, tincidunt blandit purus sodales id. Phasellus a hendrerit libero. Nunc eu ultrices libero. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer consequat egestas dui sit amet dignissim. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In sit amet cursus elit, eu dignissim elit. Ut aliquam cursus urna ultricies rhoncus. Proin vitae neque erat. Sed mollis consectetur diam eget vestibulum." },
                new Article { UserID = 1, Title = "Defensue wil nieuwe kazernes", SubTitle = "Nieuwe kazernes in Charleroi en Oost-Vlaanderen", ArticleStatusID = 1, TagID = 1, Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus consequat non justo dignissim varius. Morbi finibus magna non neque bibendum efficitur. Aliquam eu auctor sem, ut mollis erat. Donec ornare dolor ex, tincidunt blandit purus sodales id. Phasellus a hendrerit libero. Nunc eu ultrices libero. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer consequat egestas dui sit amet dignissim. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In sit amet cursus elit, eu dignissim elit. Ut aliquam cursus urna ultricies rhoncus. Proin vitae neque erat. Sed mollis consectetur diam eget vestibulum." },
                new Article { UserID = 1, Title = "Geweld tegen politie strenger", SubTitle = "Maar elke dader voor de rechtbank? Dat nu ook weer niet", ArticleStatusID = 1, TagID = 1, Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus consequat non justo dignissim varius. Morbi finibus magna non neque bibendum efficitur. Aliquam eu auctor sem, ut mollis erat. Donec ornare dolor ex, tincidunt blandit purus sodales id. Phasellus a hendrerit libero. Nunc eu ultrices libero. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer consequat egestas dui sit amet dignissim. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In sit amet cursus elit, eu dignissim elit. Ut aliquam cursus urna ultricies rhoncus. Proin vitae neque erat. Sed mollis consectetur diam eget vestibulum." },
                new Article { UserID = 1, Title = "Trumpkanaal aan banden", SubTitle = "Youtube legt pro-trumpkanaal oan aan banden vanwege nepnieuws", ArticleStatusID = 1, TagID = 1, Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus consequat non justo dignissim varius. Morbi finibus magna non neque bibendum efficitur. Aliquam eu auctor sem, ut mollis erat. Donec ornare dolor ex, tincidunt blandit purus sodales id. Phasellus a hendrerit libero. Nunc eu ultrices libero. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer consequat egestas dui sit amet dignissim. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In sit amet cursus elit, eu dignissim elit. Ut aliquam cursus urna ultricies rhoncus. Proin vitae neque erat. Sed mollis consectetur diam eget vestibulum." }
                );*/

            context.Images.AddRange(
                new Image { FileName = "politiemassaalaanwezig", Path = "uploads/politiemassaalaanwezig.jpg" },
                new Image { FileName = "moordmysterieopgelost", Path = "uploads/moordmysterieopgelost.jpg" },
                new Image { FileName = "pakjespiekbpost", Path = "uploads/pakjespiekbpost.jpg" }
                );
            context.SaveChanges();

            context.Articles.AddRange(
                new Article 
                {
                    UserID = 1, 
                    Title = "Politie massaal aanwezig voor incidenten met jongeren in Anderlecht", 
                    ShortSummary = "Donderdagavond hebben jongeren molotovcocktails en stenen gegooid in de richting van het gemeentehuis in Anderlecht. De politie is tussengekomen omstreeks 20.30. Dat bevestigt de woordvoerster van politiezone Zuid aan Bruzz.", 
                    ArticleStatusID = 1, 
                    TagID = 1, 
                    ImageID = 3,
                    Body = "Een groep van een 40-tal jongeren heeft donderdagavond stenen en brandbommen gegooid naar het gemeentehuis van Anderlecht. Dat schrijft Bruzz op basis van een reporter die ter plekke aanwezig was en wordt bevestigd door de lokale politie Brussel Zuid. Eén wagen is in brand gevlogen maar voorlopig is er geen sprake van gewonden. De politie houdt de situatie in de gaten, klinkt het." +
                    " Meer dan waarschijnlijk zijn de incidenten een reactie op het nieuws dat het Brusselse parket besloten heeft om de agenten die betrokken waren bij het overlijden van de jonge Adil, in april, niet te vervolgen.‘Rond 20.30 uur verzamelde een groep van een 40 - tal personen zich op het Raadsplein en zijn er projectielen en molotovcocktails gegooid’, klinkt het bij de politie Brussel Zuid. " +
                    "‘Eén wagen is in brand gevlogen maar er vielen geen gewonden.De politie werd niet geviseerd en is niet moeten tussenkomen.We hebben ook het waterkanon niet moeten gebruiken.Om 22 uur treedt de avondklok in werking, we zullen zien hoe de situatie evolueert.Onze mensen houden de situatie wel in de gaten, net als de burgemeester en de korpschef.’" +
                    " Adil De 19 - jarige Adil kwam om het leven toen hij tijdens een achtervolging in Anderlecht frontaal botste op een politievoertuig.Volgens het parket reed dat politievoertuig aan een lage snelheid, terwijl Adil sneller reed dan toegelaten en zijn motorhelm niet correct droeg. Donderdagvoormiddag raakte bekend dat het parket zou vragen om de betrokken agenten buiten vervolging te stellen." +
                    "In de loop van de dag bleef het rustig in Anderlecht maar de lokale politie nam wel haar voorzorgen.Verschillende politiepelotons van zowel de lokale als de federale politie stonden paraat, terwijl de federale politie ook voor versterking had gezorgd van een waterkanon en een helikopter." 
                },
                new Article
                {
                    UserID = 1,
                    ArticleStatusID = 1,
                    TagID = 1,
                    ImageID = 2,
                    Title = "Moordmysterie opgelost: achternicht schuldig aan moord op Jules Bogaerts en Jeannette Jacobs in 1991",
                    ShortSummary = "In Leuven heeft de assisenjury de 47-jarige Alinda Van der Cruysen schuldig verklaard voor de moord op het bejaarde koppel Jeanne Jacobs en Jules Bogaerts in 1991. Alinda Van der Cruysen is de achternicht van het koppel. Openbaar ministerie vordert 25 jaar opsluiting.",
                    Body = "De jury van het hof van assisen van Vlaams-Brabant in Leuven heeft Alinda Van der Cruysen (47) donderdag schuldig bevonden aan moord op Jules Bogaerts (81) en Jeannette Jacobs (78) in Tienen in 1991. Volgens de gezworenen is de voorbedachtheid aangetoond." +
                    "Het openbaar ministerie vordert 25 jaar opsluiting voor Alinda Van der Cruysen. Voor het hof van assisen van Vlaams-Brabant in Leuven heeft het openbaar ministerie donderdagavond 25 jaar opsluiting gevorderd voor Alinda Van der Cruysen. ‘Eén straf voor twee moorden’, zei procureur Hans Van Espen." +
                    "Van der Cruysen bracht het bejaarde echtpaar met extreem geweld om het leven in hun woning in Tienen op 9 december 1991. Zij is de achternicht van de slachtoffers. Volgens de jury had de vrouw wel degelijk de intentie om hen te doden en heeft zij de feiten ook met voorbedachten rade gepleegd." +
                    "Zeven juryleden stemden ja op de schuldvraag. Vijf van hen hielden het bij neen. Die eenvoudige meerderheid was niet voldoende om de schuldvraag te beantwoorden. De drie beroepsrechters moesten bijgevolg ook hun stem uitbrengen. Dat deed het antwoord overhevelen richting schuld." +
                    "‘Het echtpaar kwam op een identieke manier om het leven, door het gebruik van stomp en scherp geweld’, zei assisenvoorzitter Peter Hartoch. ‘De uiteindelijke doodsoorzaak was verstikking door het inslikken van bloed. De slachtoffers kregen ook harde slagen op hoofd en romp met diverse voorwerpen.’" +
                    "Volgens de jury staat het vast dat Van der Cruysen in het huis aanwezig was op het ogenblik van de feiten. ‘Dat blijkt uit verschillende DNA-analyses. Onder meer op de teruggevonden jeansbroek en schoenen, waarop haar DNA en bloedsporen van Bogaerts werden gevonden.’" +
                    "De gezworenen stelden in de motivering dat Alinda Van der Cruysen vermoedelijk niet alleen gehandeld heeft. Het beraad nam acht uur in beslag."
                },
                new Article
                {
                    UserID = 1,
                    ArticleStatusID = 1,
                    TagID = 1,
                    ImageID = 1,
                    Title = "‘Van Avermaet zag pakjespiek totaal niet aankomen’",
                    ShortSummary = "Bpost-baas Jean-Paul Van Avermaet heeft op 4 november toen de lockdown al bezig was tot drie keer toe gezegd dat hij geen nieuwe pakjespiek verwachtte.",
                    Body = "Dat zei Michael Freilich, parlementslid van N-VA, deze namiddag in het parlement. Freilich sprak over mismanagement door de top van Bpost. Van Avermaet deed de uitlatingen aan analisten die Bpost volgen. Ze vroegen hem verschillende keren wat hij verwachtte als gevolg van de nieuwe lockdown in België waardoor de gewone handel verplicht de deuren moest sluiten." +
                    "In de telefonische toelichting tussen Van Avermaet en de analisten zegt Van Avermaet letterlijk dat hij geen opstoot verwacht. ‘De groei van de pakjesstroom zal wellicht blijven zoals hij was. We verwachten geen nieuwe jump’, verklaarde Van Avermaet." +
                    "‘Hallucinant om te horen dat hij tot drie keer toe zegt dat hij geen grote piek verwacht terwijl de lockdown al een feit was’, zegt Freilich. Twee weken later moest Bpost vaststellen dat dag na dag nieuwe records werden gebroken. Woensdagavond zei Van Avermaet nog in het nieuwsprogramma Terzake ‘dat niemand een tweede golf had verwacht’." +
                    "‘We willen een hoorzitting met Van Avermaet, de ombudsvrouw én met de handel’ zei Freilich. Het parlementslid nodigde zijn collega’s in het parlement uit om de ‘conference call’ van Bpost alvast zelf te beluisteren. Eerder deze week in de parlementaire commissie verwierpen de Vilvadi-partijen nog de vraag tot een hoorzitting."
                }
            );

            context.SaveChanges();
        }
    }
}
