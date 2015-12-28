 using Azmanov.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Entities
{
    public class AzmanovDbSeedData : IAzmanovDbSeedData
    {
        private AzmanovContext _context;

        public AzmanovDbSeedData(AzmanovContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            #region Languages
            _context.LanguageDetails.RemoveRange(_context.LanguageDetails);
            _context.Languages.RemoveRange(_context.Languages);

            _context.SaveChanges();

            if (!_context.Languages.Any())
            {
                _context.Languages.Add(new Language() { ShortDisplay = "BG", CultureCode = "bg-BG", LongDisplay = "Bulgarian", Description = string.Empty, Default = false, CreatedDateTime = DateTime.UtcNow, ExpireDateTime = DateTime.UtcNow.AddYears(100), LanguageDetails = new List<LanguageDetail>() });
                _context.Languages.Add(new Language() { ShortDisplay = "EN", CultureCode = "en-US", LongDisplay = "English", Description = string.Empty, Default = true, CreatedDateTime = DateTime.UtcNow, ExpireDateTime = DateTime.UtcNow.AddYears(100), LanguageDetails = new List<LanguageDetail>() });
                _context.Languages.Add(new Language() { ShortDisplay = "FR", CultureCode = "fr-FR", LongDisplay = "French", Description = string.Empty, Default = false, CreatedDateTime = DateTime.UtcNow, ExpireDateTime = DateTime.UtcNow.AddYears(100), LanguageDetails = new List<LanguageDetail>() });

                _context.SaveChanges();

                var languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "БГ",
                    LongDisplay = "Български",
                    Description = string.Empty,
                    Order = 0,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "BG").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "BG",
                    LongDisplay = "Bulgarian",
                    Description = string.Empty,
                    Order = 0,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "BG").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "BG",
                    LongDisplay = "Bulgarien",
                    Description = string.Empty,
                    Order = 0,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "BG").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "АН",
                    LongDisplay = "Английски",
                    Description = string.Empty,
                    Order = 1,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "EN").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "EN",
                    LongDisplay = "English",
                    Description = string.Empty,
                    Order = 1,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "EN").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "EN",
                    LongDisplay = "Anglais",
                    Description = string.Empty,
                    Order = 1,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "EN").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "ФР",
                    LongDisplay = "Френски",
                    Description = string.Empty,
                    Order = 2,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "FR").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "FR",
                    LongDisplay = "French",
                    Description = string.Empty,
                    Order = 2,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "FR").LanguageDetails.Add(languageDetails);

                languageDetails = new LanguageDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "FR",
                    LongDisplay = "Français",
                    Description = string.Empty,
                    Order = 2,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100)
                };

                _context.Languages.First(p => p.ShortDisplay == "FR").LanguageDetails.Add(languageDetails);

                _context.LanguageDetails.AddRange(_context.Languages.First(p => p.ShortDisplay == "BG").LanguageDetails);
                _context.LanguageDetails.AddRange(_context.Languages.First(p => p.ShortDisplay == "EN").LanguageDetails);
                _context.LanguageDetails.AddRange(_context.Languages.First(p => p.ShortDisplay == "FR").LanguageDetails);
                _context.SaveChanges();
            }
            #endregion

            #region Menus
            _context.MenuItemDetails.RemoveRange(_context.MenuItemDetails);
            _context.MenuItems.RemoveRange(_context.MenuItems);
            _context.Menus.RemoveRange(_context.Menus);

            _context.SaveChanges();

            if (!_context.Menus.Any())
            {
                var mainmenu = new Menu()
                {
                    ShortDisplay = "main",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MenuItems = new List<MenuItem>()
                };

                _context.Menus.Add(mainmenu);

                var menuitem = new MenuItem()
                {
                    ShortDisplay = "autobiography",
                    Controller = "Autobiography",
                    Action = "Index",
                    Attribute = string.Empty,
                    Order = 0,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MenuItemDetails = new List<MenuItemDetail>()
                };

                var menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "Autobiography",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "Autobiographie",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "Автобиография",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                mainmenu.MenuItems.Add(menuitem);

                _context.MenuItems.Add(menuitem);
                _context.MenuItemDetails.AddRange(menuitem.MenuItemDetails);

                menuitem = new MenuItem()
                {
                    ShortDisplay = "gallery",
                    Controller = "gallery",
                    Action = "Index",
                    Attribute = string.Empty,
                    Order = 1,
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MenuItemDetails = new List<MenuItemDetail>()
                };

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "Gallery",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "Galerie",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "Галерия",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                mainmenu.MenuItems.Add(menuitem);

                _context.MenuItems.Add(menuitem);
                _context.MenuItemDetails.AddRange(menuitem.MenuItemDetails);

                menuitem = new MenuItem()
                {
                    ShortDisplay = "events",
                    Controller = "events",
                    Action = "Index",
                    Attribute = string.Empty,
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 2,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MenuItemDetails = new List<MenuItemDetail>()
                };

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "Appearances",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "Аpparitions",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "Изяви",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                mainmenu.MenuItems.Add(menuitem);

                _context.MenuItems.Add(menuitem);
                _context.MenuItemDetails.AddRange(menuitem.MenuItemDetails);

                menuitem = new MenuItem()
                {
                    ShortDisplay = "media",
                    Controller = "media",
                    Action = "Index",
                    Attribute = string.Empty,
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 3,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MenuItemDetails = new List<MenuItemDetail>()
                };

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "Media",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "Médiatique",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "Медия",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                mainmenu.MenuItems.Add(menuitem);

                _context.MenuItems.Add(menuitem);
                _context.MenuItemDetails.AddRange(menuitem.MenuItemDetails);

                menuitem = new MenuItem()
                {
                    ShortDisplay = "contact",
                    Controller = "contact",
                    Action = "Index",
                    Attribute = string.Empty,
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 4,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MenuItemDetails = new List<MenuItemDetail>()
                };

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    ShortDisplay = "Contact",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    ShortDisplay = "Contactez",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                menuitemdetail = new MenuItemDetail()
                {
                    InLanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    ShortDisplay = "Контакт",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                };

                menuitem.MenuItemDetails.Add(menuitemdetail);

                mainmenu.MenuItems.Add(menuitem);

                _context.MenuItems.Add(menuitem);
                _context.MenuItemDetails.AddRange(menuitem.MenuItemDetails);

                _context.SaveChanges();
            }

            #endregion

            #region Autobiography
            _context.AutobiographyDetails.RemoveRange(_context.AutobiographyDetails);
            _context.Autobiographies.RemoveRange(_context.Autobiographies);

            _context.SaveChanges();

            if (!_context.Autobiographies.Any())
            {
                var autobiography = new Autobiography()
                {
                    ImageUrl = "~/img/autobiography/CV.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    AutobiographyDetails = new List<AutobiographyDetail>()
                };

                _context.Autobiographies.Add(autobiography);

                var autobiographyDetail = new AutobiographyDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Text = @"<STRONG>TODOR AZMANOV</STRONG><br>is a Bulgarian sculptor,
                        born in 
      1929 in the historic town of <EM> Koprivshtitsa </EM>.He lives and works in 
      the city of <EM> Plovdiv </EM>.He is a member of the <EM> Union of Bulgarian
      Artists,
                        the Plovdiv group </EM>.<br>
<br><EM> Mr.Azmanov's</EM> creations are primarily 
      portrait sculptures,
                        both in realistic and abstract style.His works are
  exhibited in art galleries and museums in <EM>Plovdiv</EM> (the
  <EM> Ethnographic Museum, and the Museum of the National Liberation
   Movement</EM>), in <EM>Algeria's National Gallery</EM>, and make part of 
      private collections in <EM>Belgium, the Netherlands, Israel, Greece,
      Switzerland and Germany</EM>.<br>
<br><EM>Mr.Azmanov</EM> founded a<EM> Sculpture School
      in Algeria in 1975 (in the capital city Algiers)</EM>, upon invitation of
      the<EM>Algerian Minister of Culture</EM>. With this initiative he became
      one of the pioneers of the portrait sculpture in the<EM> Islamic
      world</EM>.He is an<EM> honorary member of the Union of Algerian
      Artists</EM>.Some of his works are owned by the former<EM> president of
      Algeria Huarri Boumedien</EM>, as well as by the <EM>Historical Museum to
      the Navy Academy of Algeria</EM>.<br>
<br><EM>Todor Azmanov </EM>is the author of the series of
      portraits in the<EM> Renaissance Wall in the town of Smolian</EM>, at the
      heart of the<EM> Rodopa </EM>Mountain in <EM>Bulgaria</EM>.
<br>
He has held a series of independent and collective exhibitions nationally and internationally (<EM>Alger, 1975 and Hungary, 1968</EM>)."
                };
                autobiography.AutobiographyDetails.Add(autobiographyDetail);
                _context.AutobiographyDetails.Add(autobiographyDetail);

                autobiographyDetail = new AutobiographyDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Text = @"<STRONG>TODOR 
      AZMANOV</STRONG> est sculpteur bulgare, ne en 1929 a 
      <EM>Koprivshtitsa</EM>, ville historique en <EM>Bulgarie</EM>. II vit et 
      travaille a <EM>Plovdiv.M. Azmanov </EM>est membre de <EM>l'Union des 
      Artistes Bulgares</EM>. II est portraitiste, dont les oeuvres, fakes en marbre et pierre, sont executees dans un style realiste ou abstrait.<br>
<br>
Les oeuvres de <EM>M. 
      Azmanov </EM>sont exposees dans des galleries d'art et des musees a 
      <EM>Plovdiv </EM>(<EM>le musee d'Ethnographie, le musee du Mouvement de 
      liberation nationale</EM>), dans la <EM>Gallerie d'Art nationale 
      d'Algerie</EM>, et se trouvent egalement dans des collections privees en 
      <EM>Belgique, aux Pays-Bas, en Israel, en Grece, en Suisse et en 
      Allemagne</EM>.<br>
<br><EM>M. 
      Azmanov</EM> a fonde <EM>l'Ecole de sculpture a Alger en 1975</EM>, a 
      l'invitation du ministre de la <EM>Culture algerien</EM>, devenant ainsi 
      l'un des pionniers de la sculpture portraitiste dans le monde musulman. II 
      est <EM>membre d'honneur de l'Union des Artistes Algeriens</EM>.<br>
<br><EM>Todor Azmanov </EM>est 
      l'auteur des portraits sur le <EM>Mur de la Renaissance a Smolian</EM>, 
      dans les montagnes des <EM>Rhodopes</EM>.<br>
II a 
      participe dans de nombreuses expositions collectives et personnelles, a 
      niveau national et international, notamment a <EM>Alger en 1975 et en 
      Hongrie en 1968</EM>."
                };
                autobiography.AutobiographyDetails.Add(autobiographyDetail);
                _context.AutobiographyDetails.Add(autobiographyDetail);

                autobiographyDetail = new AutobiographyDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Text = @"<STRONG>ТОДОР АЗМАНОВ</STRONG> е български скулптор, роден през 1929 г. в историческия град <EM>Копривщица</EM>. Той живее и работи в град <EM>Пловдив</EM>. Член е на Съюза на българските художници – Пловдивската група.<br>
<br>Произведенията на г-н <EM>Азманов </EM>са предимно портретни скулптури в реалистичен и абстрактен стил. Работите му се излагат в художествени галерии и музеи в <EM>Пловдив: Етнографски музей</EM> и <EM>Музея на Националното Освободително Движение</EM>, в <EM>Националната Галерия в Алжир</EM>, и са част от частни колекции в <EM>Белгия, Холандия, Израел, Гърция, Швейцария и Германия.</EM>
<br>
<br>Г-н <EM>Азманов</EM> е основател на <EM>Училище за скулптура в гр.Алжир (1975 г.)</EM> - столицата на Алжир, по покана на <EM>Алжирския Министър на културата</EM>. С тази инициатива той се превърна в един от пионерите на портретната скулптура в <EM>ислямския свят</EM>. Той е и <EM>почетен член на Съюза на Алжирските художници</EM>. Някои от неговите творби са собственост на предишния <EM>президент на Алжир – Хуари Боумедиен</EM>, както и на <EM>Историческия музей към Военноморската Академия в Алжир</EM>.
<br>
<br><EM>Тодор Азманов </EM>е автор на редица портрети във “<EM>Възрожденската Стена</EM>” в гр.<EM>Смолян</EM>, разположен в сърцето на <EM>Родопи </EM>планина.
<br>Той е правил поредица от самостоятелни и колективни изложби на национално и международно ниво: <EM>Алжир (1975) и Унгария (1968).</EM>"
                };
                autobiography.AutobiographyDetails.Add(autobiographyDetail);
                _context.AutobiographyDetails.Add(autobiographyDetail);

                _context.SaveChanges();
            }
            #endregion

            #region Gallery
            _context.GalleryDetails.RemoveRange(_context.GalleryDetails);
            _context.Galleries.RemoveRange(_context.Galleries);

            _context.SaveChanges();

            if (!_context.Galleries.Any())
            {
                var gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/001.jpg",
                    ImageUrl = $"~/img/gallery/001.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 1,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                var galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"East - West"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"L'est - L'ouest"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/002.jpg",
                    ImageUrl = $"~/img/gallery/002.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 2,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Азиатка - Анфас"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/003.jpg",
                    ImageUrl = $"~/img/gallery/003.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 3,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Etude"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Étude"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Етюд"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/004.jpg",
                    ImageUrl = $"~/img/gallery/004.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 4,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/005.jpg",
                    ImageUrl = $"~/img/gallery/005.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 5,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/006.jpg",
                    ImageUrl = $"~/img/gallery/006.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 6,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/007.jpg",
                    ImageUrl = $"~/img/gallery/007.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 7,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/008.jpg",
                    ImageUrl = $"~/img/gallery/008.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 8,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/009.jpg",
                    ImageUrl = $"~/img/gallery/009.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 9,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/010.jpg",
                    ImageUrl = $"~/img/gallery/010.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 10,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/011.jpg",
                    ImageUrl = $"~/img/gallery/011.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 11,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/012.jpg",
                    ImageUrl = $"~/img/gallery/012.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 12,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/013.jpg",
                    ImageUrl = $"~/img/gallery/013.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 13,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/014.jpg",
                    ImageUrl = $"~/img/gallery/014.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 14,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/015.jpg",
                    ImageUrl = $"~/img/gallery/015.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 15,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/016.jpg",
                    ImageUrl = $"~/img/gallery/016.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 16,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/017.jpg",
                    ImageUrl = $"~/img/gallery/017.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 17,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                //***************************************
                gallery = new Gallery()
                {
                    ThumbnailUrl = $"~/img/gallery/small/018.jpg",
                    ImageUrl = $"~/img/gallery/018.jpg",
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 18,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    GalleryDetails = new List<GalleryDetail>()
                };

                _context.Galleries.Add(gallery);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = $"Asian - Full-Face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = $"Аsiatique - Plein-face"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                galleryDetail = new GalleryDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = $"Изток - Запад"
                };
                gallery.GalleryDetails.Add(galleryDetail);
                _context.GalleryDetails.Add(galleryDetail);

                // Save data
                _context.SaveChanges();
            }
            #endregion

            #region Events
            _context.EventPictureDetails.RemoveRange(_context.EventPictureDetails);
            _context.EventPictures.RemoveRange(_context.EventPictures);
            _context.EventDetails.RemoveRange(_context.EventDetails);
            _context.Events.RemoveRange(_context.Events);

            _context.SaveChanges();

            if (!_context.Events.Any())
            {
                var e = new Event()
                {
                    EventDate = new DateTime(2009, 01, 01),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 1,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    EventDetails = new List<EventDetail>(),
                    EventPictures = new List<EventPicture>()
                };

                _context.Events.Add(e);

                //****************************************
                var eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "Европейския Парламент в Брюксел",
                    Body = @"През 2009 г-н Азманов представи творбите си в централната сграда на<BR>
& nbsp;   <STRONG><EM> Европейския Парламент в Брюксел </EM></STRONG><BR>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "Европейския Парламент в Брюксел",
                    Body = @"През 2009 г-н Азманов представи творбите си в централната сграда на<BR>
& nbsp;   <STRONG><EM> Европейския Парламент в Брюксел </EM></STRONG><BR>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "Европейския Парламент в Брюксел",
                    Body = @"През 2009 г-н Азманов представи творбите си в централната сграда на<BR>
& nbsp;   <STRONG><EM> Европейския Парламент в Брюксел </EM></STRONG><BR>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                var eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-6.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                var eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-7.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                //***************************************
                e = new Event()
                {
                    EventDate = new DateTime(2004, 11, 01),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 2,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    EventDetails = new List<EventDetail>(),
                    EventPictures = new List<EventPicture>()
                };

                _context.Events.Add(e);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "Стената на възрожденците",
                    Body = @"Стената на възрожденците<BR> <STRONG><EM>Смолян (деня на народните будители)</EM></STRONG>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "Стената на възрожденците",
                    Body = @"Стената на възрожденците<BR> <STRONG><EM>Смолян (деня на народните будители)</EM></STRONG>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "Стената на възрожденците",
                    Body = @"Стената на възрожденците<BR> <STRONG><EM>Смолян (деня на народните будители)</EM></STRONG>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/Stenata.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = ""
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                //******************************************
                e = new Event()
                {
                    EventDate = new DateTime(2003, 12, 01),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 3,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    EventDetails = new List<EventDetail>(),
                    EventPictures = new List<EventPicture>()
                };

                _context.Events.Add(e);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "Обща годишна изложба",
                    Body = @"<STRONG>СБХ – Пловдив 2003/декември-януари</STRONG>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "Обща годишна изложба",
                    Body = @"<STRONG>СБХ – Пловдив 2003/декември-януари</STRONG>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "Обща годишна изложба",
                    Body = @"<STRONG>СБХ – Пловдив 2003/декември-януари</STRONG>"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                //******************************************
                e = new Event()
                {
                    EventDate = new DateTime(2003, 12, 01),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 4,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    EventDetails = new List<EventDetail>(),
                    EventPictures = new List<EventPicture>()
                };

                _context.Events.Add(e);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "Национална галерия Алжир",
                    Body = @"(<STRONG><EM>Емир Абдел Кадер</EM></STRONG>- бюст)"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "Национална галерия Алжир",
                    Body = @"(<STRONG><EM>Емир Абдел Кадер</EM></STRONG>- бюст)"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "Национална галерия Алжир",
                    Body = @"(<STRONG><EM>Емир Абдел Кадер</EM></STRONG>- бюст)"
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                //****************************************
                e = new Event()
                {
                    EventDate = new DateTime(2003, 12, 01),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 5,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    EventDetails = new List<EventDetail>(),
                    EventPictures = new List<EventPicture>()
                };

                _context.Events.Add(e);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "Европейския Парламент в Брюксел",
                    Body = @"През 2003 г-н Азманов представи творбите си в централната сграда на <STRONG><EM>Европейския Парламент в Брюксел</EM></STRONG> - надслов ""България, цвете от букета на Европа""."
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "Европейския Парламент в Брюксел",
                    Body = @"През 2003 г-н Азманов представи творбите си в централната сграда на<BR>
 <STRONG><EM>Европейския Парламент в Брюксел</EM></STRONG><BR> - надслов ""България,
                    цвете от букета на Европа""."
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventDetail = new EventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "Европейския Парламент в Брюксел",
                    Body = @"През 2003 г-н Азманов представи творбите си в централната сграда на<BR>
 <STRONG><EM>Европейския Парламент в Брюксел</EM></STRONG><BR> - надслов ""България,
                    цвете от букета на Европа""."
                };

                e.EventDetails.Add(eventDetail);
                _context.EventDetails.Add(eventDetail);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-1.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = "Централно вход на Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = "Централно вход на Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = "Централно вход на Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-2.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = "Изложбената зала в Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = "Изложбената зала в Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = "Изложбената зала в Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-2.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = "Изложбената зала в Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = "Изложбената зала в Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = "Изложбената зала в Европейския Парламент - Брюксел"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-4.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = "Автора с евро - парламентаристи <BR>{от ляво на дясно:<BR> г - н.Даскалов (посланик на България в Европейския Съюз),<BR> г - н.Азманов(автор),<BR> г - н.Хил Роблес (екс.президент на Европейския Парламент)."
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = "Автора с евро - парламентаристи <BR>{от ляво на дясно:<BR> г - н.Даскалов (посланик на България в Европейския Съюз),<BR> г - н.Азманов(автор),<BR> г - н.Хил Роблес (екс.президент на Европейския Парламент)."
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = "Автора с евро - парламентаристи <BR>{от ляво на дясно:<BR> г - н.Даскалов (посланик на България в Европейския Съюз),<BR> г - н.Азманов(автор),<BR> г - н.Хил Роблес (екс.президент на Европейския Парламент)."
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);

                eventPicture = new EventPicture()
                {
                    ImageUrl = $"~/img/events/EU-5.jpg",
                    EventPictureDetail = new List<EventPictureDetail>()
                };

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Name = "Постер"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Name = "Постер"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                eventPictureDetail = new EventPictureDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Name = "Постер"
                };

                eventPicture.EventPictureDetail.Add(eventPictureDetail);
                _context.EventPictureDetails.Add(eventPictureDetail);

                e.EventPictures.Add(eventPicture);
                _context.EventPictures.Add(eventPicture);


                // Save data
                _context.SaveChanges();
            }
            #endregion

            #region Media
            _context.MediaEventDetails.RemoveRange(_context.MediaEventDetails);
            _context.MediaEvents.RemoveRange(_context.MediaEvents);

            _context.SaveChanges();

            if (!_context.MediaEvents.Any())
            {
                //****************************************
                var e = new MediaEvent()
                {
                    EventDate = new DateTime(1999, 09, 13),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 1,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MediaEventDetails = new List<MediaEventDetail>()
                };

                _context.MediaEvents.Add(e);

                var eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "МУЗИТЕ - Скулптор разбунва ислямския свят",
                    Intro = @"
<p>Пловдивският скулптор Тодор Азманов е на 70 години. Завършил е Геодезия и картография, но от 1949 г. се е отдал на скулптурата. 
В момента излага 30 свои творби в двора на Новотел ""Пловдив""</p>
<p>- Скулптурите ви бяха пред кметството на район ""Север"", защо ги преместихте в Новотела?</p>
<p>-Направих юбилейна изложба по повод на моята 70 - годишнина. За първи път аз се реших да излагам под открито небе, подредих 42 работи.
Обаче една нощ вандали разбиха моята творба ""Възпоменание"". Пияниците бяха съборили всички скулптори, а точно тази, която ми е най-любимата 
бяха потрошили. Тя е изработена от черна мозайка и е събирателен образ на тъгуващата жена. За да не се повтарят тези неща, преместих експозицията си в Новотела.
В момента същата изложба обикаля задочно света и по мрежата на Интернет.</p>",
                    Body = @"
<p>Вече имам дори и няколко откупки от чужбина. Боли ме за унищожената скулптура, но не съм се отказал да излагам на открито, вярвам че изкуството трябва да 
бъде изнесено сред хората, а не затворено в музеите.</p> 
<p>-Вие сте живяли три го дини в Алжир...</p> 
<p>-Отидох там уж на ра бота като геодезист, но тъй като не знаех и думичка френски, започнах да се занимавам по сериозно с историята на Алжир.
През 1975 г., алжирският министър на културата ми даде идеята да направя серия от скулпторни портрети на националните герои на тази арабска страна. 
Направих изложба от цели 30 скулптури, сред които имаше и бюст на тогаваш ния президент Хоари Бомидиен.
Тази експозиция направи истинска революция в Ислямския свят, защото Корана забранява на вярващите да рисуват и да ваят човешки образи.
От целия арабски свят се стичаше народ да види това чудо. През залата се извървя и дипломатическият корпус, посланиците не вярваха на очите си. 
От Художествената Академия пък дойдоха да ми благодарят работещите, там френски преподаватели.
За тях аз бях истински герой, защото бях разчупил канони, които са ги мъчели десетилетия наред. 
Бях приет и за член на Съюза на алжирските художници. 
А министърът на културата ме награди с безплатно 10 дневно пътуване до Париж с цялото ми семейство.</p> 
<p>-А какво отнесохте със себе си от френската столица?</p> 
<p>-Незабравими спомени. Никога няма да забравя първата си среща с творите на Роден. 
Когато влезнах в неговия музей и видях ""Вратата на Ада"", останах като поразен.
От тогава тази скулптура е непрекъснато пред очите ми.Обиколих и Лувъра, и Версай. 
След това мое посещение в Париж реших да работя само с камък. 
Най - щастлив ме правят обаче не моите творби от мрамор, а моето живо творение - дъщеря ми Албена. 
През 1994 г. тя стана професор по политология в Париж. 
В момента живее в Брюксел, защото е женена за съветника на генералния секретар на ЗЕС за Източна Европа Стефан Елгерсман.
Двамата живеят в най-шикозния квартал на белгийската столица, където се намират и всички големи галерии.</p>
<p><STRONG> Разговаря: Диана СТАВРЕВА </STRONG></p>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "МУЗИТЕ - Скулптор разбунва ислямския свят",
                    Intro = @"
<p>Пловдивският скулптор Тодор Азманов е на 70 години. Завършил е Геодезия и картография, но от 1949 г. се е отдал на скулптурата. 
В момента излага 30 свои творби в двора на Новотел ""Пловдив""</p>
<p>- Скулптурите ви бяха пред кметството на район ""Север"", защо ги преместихте в Новотела?</p>
<p>-Направих юбилейна изложба по повод на моята 70 - годишнина. За първи път аз се реших да излагам под открито небе, подредих 42 работи.
Обаче една нощ вандали разбиха моята творба ""Възпоменание"". Пияниците бяха съборили всички скулптори, а точно тази, която ми е най-любимата 
бяха потрошили. Тя е изработена от черна мозайка и е събирателен образ на тъгуващата жена. За да не се повтарят тези неща, преместих експозицията си в Новотела.
В момента същата изложба обикаля задочно света и по мрежата на Интернет.</p>",
                    Body = @"
<p>Вече имам дори и няколко откупки от чужбина. Боли ме за унищожената скулптура, но не съм се отказал да излагам на открито, вярвам че изкуството трябва да 
бъде изнесено сред хората, а не затворено в музеите.</p> 
<p>-Вие сте живяли три го дини в Алжир...</p> 
<p>-Отидох там уж на ра бота като геодезист, но тъй като не знаех и думичка френски, започнах да се занимавам по сериозно с историята на Алжир.
През 1975 г., алжирският министър на културата ми даде идеята да направя серия от скулпторни портрети на националните герои на тази арабска страна. 
Направих изложба от цели 30 скулптури, сред които имаше и бюст на тогаваш ния президент Хоари Бомидиен.
Тази експозиция направи истинска революция в Ислямския свят, защото Корана забранява на вярващите да рисуват и да ваят човешки образи.
От целия арабски свят се стичаше народ да види това чудо. През залата се извървя и дипломатическият корпус, посланиците не вярваха на очите си. 
От Художествената Академия пък дойдоха да ми благодарят работещите, там френски преподаватели.
За тях аз бях истински герой, защото бях разчупил канони, които са ги мъчели десетилетия наред. 
Бях приет и за член на Съюза на алжирските художници. 
А министърът на културата ме награди с безплатно 10 дневно пътуване до Париж с цялото ми семейство.</p> 
<p>-А какво отнесохте със себе си от френската столица?</p> 
<p>-Незабравими спомени. Никога няма да забравя първата си среща с творите на Роден. 
Когато влезнах в неговия музей и видях ""Вратата на Ада"", останах като поразен.
От тогава тази скулптура е непрекъснато пред очите ми.Обиколих и Лувъра, и Версай. 
След това мое посещение в Париж реших да работя само с камък. 
Най - щастлив ме правят обаче не моите творби от мрамор, а моето живо творение - дъщеря ми Албена. 
През 1994 г. тя стана професор по политология в Париж. 
В момента живее в Брюксел, защото е женена за съветника на генералния секретар на ЗЕС за Източна Европа Стефан Елгерсман.
Двамата живеят в най-шикозния квартал на белгийската столица, където се намират и всички големи галерии.</p>
<p><STRONG> Разговаря: Диана СТАВРЕВА </STRONG></p>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "МУЗИТЕ - Скулптор разбунва ислямския свят",
                    Intro = @"
<p>Пловдивският скулптор Тодор Азманов е на 70 години. Завършил е Геодезия и картография, но от 1949 г. се е отдал на скулптурата. 
В момента излага 30 свои творби в двора на Новотел ""Пловдив""</p>
<p>- Скулптурите ви бяха пред кметството на район ""Север"", защо ги преместихте в Новотела?</p>
<p>-Направих юбилейна изложба по повод на моята 70 - годишнина. За първи път аз се реших да излагам под открито небе, подредих 42 работи.
Обаче една нощ вандали разбиха моята творба ""Възпоменание"". Пияниците бяха съборили всички скулптори, а точно тази, която ми е най-любимата 
бяха потрошили. Тя е изработена от черна мозайка и е събирателен образ на тъгуващата жена. За да не се повтарят тези неща, преместих експозицията си в Новотела.
В момента същата изложба обикаля задочно света и по мрежата на Интернет.</p>",
                    Body = @"
<p>Вече имам дори и няколко откупки от чужбина. Боли ме за унищожената скулптура, но не съм се отказал да излагам на открито, вярвам че изкуството трябва да 
бъде изнесено сред хората, а не затворено в музеите.</p> 
<p>-Вие сте живяли три го дини в Алжир...</p> 
<p>-Отидох там уж на ра бота като геодезист, но тъй като не знаех и думичка френски, започнах да се занимавам по сериозно с историята на Алжир.
През 1975 г., алжирският министър на културата ми даде идеята да направя серия от скулпторни портрети на националните герои на тази арабска страна. 
Направих изложба от цели 30 скулптури, сред които имаше и бюст на тогаваш ния президент Хоари Бомидиен.
Тази експозиция направи истинска революция в Ислямския свят, защото Корана забранява на вярващите да рисуват и да ваят човешки образи.
От целия арабски свят се стичаше народ да види това чудо. През залата се извървя и дипломатическият корпус, посланиците не вярваха на очите си. 
От Художествената Академия пък дойдоха да ми благодарят работещите, там френски преподаватели.
За тях аз бях истински герой, защото бях разчупил канони, които са ги мъчели десетилетия наред. 
Бях приет и за член на Съюза на алжирските художници. 
А министърът на културата ме награди с безплатно 10 дневно пътуване до Париж с цялото ми семейство.</p> 
<p>-А какво отнесохте със себе си от френската столица?</p> 
<p>-Незабравими спомени. Никога няма да забравя първата си среща с творите на Роден. 
Когато влезнах в неговия музей и видях ""Вратата на Ада"", останах като поразен.
От тогава тази скулптура е непрекъснато пред очите ми.Обиколих и Лувъра, и Версай. 
След това мое посещение в Париж реших да работя само с камък. 
Най - щастлив ме правят обаче не моите творби от мрамор, а моето живо творение - дъщеря ми Албена. 
През 1994 г. тя стана професор по политология в Париж. 
В момента живее в Брюксел, защото е женена за съветника на генералния секретар на ЗЕС за Източна Европа Стефан Елгерсман.
Двамата живеят в най-шикозния квартал на белгийската столица, където се намират и всички големи галерии.</p>
<p><STRONG> Разговаря: Диана СТАВРЕВА </STRONG></p>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                //****************************************
                e = new MediaEvent()
                {
                    EventDate = new DateTime(2000, 11, 1),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 2,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MediaEventDetails = new List<MediaEventDetail>()
                };

                _context.MediaEvents.Add(e);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = @"
Вестник Труд  / КУЛТУРА<br>
Азманов: Горд съм, че вая личности от Възраждането<br>
Скулпторът прави барелеф на смолянски будители",
                    Intro = @"
<p>Скулпторът Тодор Азманов е майстор на двата барелефа, с които ще се украси Смолян по случаи Деня на народните будители. 
Паметниците от мрамор са на възрожденците <STRONG>Хаджи Иван Бечев</STRONG> и <STRONG>Сава Стратев</STRONG></p>",
                    Body = @"
- Г-н Азманов, в Деня на народните будители вие подарявате два паметника на Смолян?</p>
<p>- 1 ноември е подходящ повод отново да се срещнем с ярките личности на нашето Възраждане. Без тяхното ярко родолюбие и неуморна работа за националното 
самосъзнание, за независима църква и родно училище, народът ни щеше още дълго да тъне в забрава и опасността от пълното му затриване и забвение 
щеше да е реална. За мене е чест, че работя образите на хората от пантеона на нашето духовно развитие.</p>
<p>- Как избрахте личностите?</p>
<p>- Родопчани са свързани с рода си хора. Наследниците на Хаджи Иван Бечев са решили да увековечат славния си роднина. Направили инициативен комитет, след това ме 
поканиха мен. И така започнах барелефа на Бечев. С паметника на Сава Стратев или Келеш Саващо, както са му викали, историята е подобна. 
Инициативата идва от хората. Аз се включвам впоследствие, но работя с огромно удоволствие. Защото тези хора са личностите на родопското Възраждане.</p>
<p>- Имената на Хаджи Бечев и Келеш Саващо не присъстват често на различните тържества и чествания?</p>
<p>- Да, има много ярки личности, които имат значим принос в духовното пробуждане и народностно осъзнаване на българите, но не ги познаваме. 
Хаджи Иван Бечев например е родоначалникът на днешния Хаджииванов род в Устово. Корените на този род ни отвеждат в разломните времена на 17-и и 18-и век, 
когато част от родопските българи са били насилствено помохамеданчени. Той е сред най-дейните противници и на гъркоманството и ярък привърженик на 
самостоятелната българска църква. За Сава Стратев са писали доста краеведите. Фамилията му обаче никой не знае, защото навсякъде е изписан прякорът му - 
Келеш Саващо, което е израз на неговата смелост и упоритост в отстояването на българщината. Той е бил изкусен, знатен и търсен майстор бакърджия, но си 
спечелил слава и като човек, който милее за народните работи. Пет години в края на 19-и век той е бил мухтар (кмет) на Устово. Той е първият управник, 
който се е противопоставил на Ксантийската митрополия, когато е искала да повиши владиш-ките данъци. Нечувана дързост е проявил, когато се опънал на гръцкия 
владика Милетий, за да се пребори за оцеляването и спасяването на българското в планината. Той открито е заявил: „Християните в Родопите са българи и не 
искат да ги идентифицират като гърци!"". Келеш Саващо е инициатор за построяването на устовската църква ""Света Богородица"", изгражда ново училище, 
помага на първите учители.</p>
<p>- Пловдивчани  ви познават от двете изложби, където  показвахте основно абстрактни пластики.</p>
<p>- В рамките на Месеца на културата аз показах една експозиция в градинката пред община ""Север"". Тази изложба нарекох юбилейна във връзка със 70-ата 
ми годишнина. След това от новотел ""Пловдив"" ме поканиха да ситуирам работите си край алеите на комплекса. Аз правя абстрактни пластики и
портрети.Сред тях е портретът на една въз рожденска баба от Копривщица, който прави голямо впечатление. Така че тази тема ми е интересна и често
си работя за собствено удоволствие.
<p><STRONG><BR>Интервю на Евелина ВЕЛИЧКОВА</STRONG></p>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    Title = @"
Вестник Труд  / КУЛТУРА<br>
Азманов: Горд съм, че вая личности от Възраждането<br>
Скулпторът прави барелеф на смолянски будители",
                    Intro = @"
<p>Скулпторът Тодор Азманов е майстор на двата барелефа, с които ще се украси Смолян по случаи Деня на народните будители. 
Паметниците от мрамор са на възрожденците <STRONG>Хаджи Иван Бечев</STRONG> и <STRONG>Сава Стратев</STRONG></p>",
                    Body = @"
- Г-н Азманов, в Деня на народните будители вие подарявате два паметника на Смолян?</p>
<p>- 1 ноември е подходящ повод отново да се срещнем с ярките личности на нашето Възраждане. Без тяхното ярко родолюбие и неуморна работа за националното 
самосъзнание, за независима църква и родно училище, народът ни щеше още дълго да тъне в забрава и опасността от пълното му затриване и забвение 
щеше да е реална. За мене е чест, че работя образите на хората от пантеона на нашето духовно развитие.</p>
<p>- Как избрахте личностите?</p>
<p>- Родопчани са свързани с рода си хора. Наследниците на Хаджи Иван Бечев са решили да увековечат славния си роднина. Направили инициативен комитет, след това ме 
поканиха мен. И така започнах барелефа на Бечев. С паметника на Сава Стратев или Келеш Саващо, както са му викали, историята е подобна. 
Инициативата идва от хората. Аз се включвам впоследствие, но работя с огромно удоволствие. Защото тези хора са личностите на родопското Възраждане.</p>
<p>- Имената на Хаджи Бечев и Келеш Саващо не присъстват често на различните тържества и чествания?</p>
<p>- Да, има много ярки личности, които имат значим принос в духовното пробуждане и народностно осъзнаване на българите, но не ги познаваме. 
Хаджи Иван Бечев например е родоначалникът на днешния Хаджииванов род в Устово. Корените на този род ни отвеждат в разломните времена на 17-и и 18-и век, 
когато част от родопските българи са били насилствено помохамеданчени. Той е сред най-дейните противници и на гъркоманството и ярък привърженик на 
самостоятелната българска църква. За Сава Стратев са писали доста краеведите. Фамилията му обаче никой не знае, защото навсякъде е изписан прякорът му - 
Келеш Саващо, което е израз на неговата смелост и упоритост в отстояването на българщината. Той е бил изкусен, знатен и търсен майстор бакърджия, но си 
спечелил слава и като човек, който милее за народните работи. Пет години в края на 19-и век той е бил мухтар (кмет) на Устово. Той е първият управник, 
който се е противопоставил на Ксантийската митрополия, когато е искала да повиши владиш-ките данъци. Нечувана дързост е проявил, когато се опънал на гръцкия 
владика Милетий, за да се пребори за оцеляването и спасяването на българското в планината. Той открито е заявил: „Християните в Родопите са българи и не 
искат да ги идентифицират като гърци!"". Келеш Саващо е инициатор за построяването на устовската църква ""Света Богородица"", изгражда ново училище, 
помага на първите учители.</p>
<p>- Пловдивчани  ви познават от двете изложби, където  показвахте основно абстрактни пластики.</p>
<p>- В рамките на Месеца на културата аз показах една експозиция в градинката пред община ""Север"". Тази изложба нарекох юбилейна във връзка със 70-ата 
ми годишнина. След това от новотел ""Пловдив"" ме поканиха да ситуирам работите си край алеите на комплекса. Аз правя абстрактни пластики и
портрети.Сред тях е портретът на една въз рожденска баба от Копривщица, който прави голямо впечатление. Така че тази тема ми е интересна и често
си работя за собствено удоволствие.
<p><STRONG><BR>Интервю на Евелина ВЕЛИЧКОВА</STRONG></p>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = @"
Вестник Труд  / КУЛТУРА<br>
Азманов: Горд съм, че вая личности от Възраждането<br>
Скулпторът прави барелеф на смолянски будители",
                    Intro = @"
<p>Скулпторът Тодор Азманов е майстор на двата барелефа, с които ще се украси Смолян по случаи Деня на народните будители. 
Паметниците от мрамор са на възрожденците <STRONG>Хаджи Иван Бечев</STRONG> и <STRONG>Сава Стратев</STRONG></p>",
                    Body = @"
- Г-н Азманов, в Деня на народните будители вие подарявате два паметника на Смолян?</p>
<p>- 1 ноември е подходящ повод отново да се срещнем с ярките личности на нашето Възраждане. Без тяхното ярко родолюбие и неуморна работа за националното 
самосъзнание, за независима църква и родно училище, народът ни щеше още дълго да тъне в забрава и опасността от пълното му затриване и забвение 
щеше да е реална. За мене е чест, че работя образите на хората от пантеона на нашето духовно развитие.</p>
<p>- Как избрахте личностите?</p>
<p>- Родопчани са свързани с рода си хора. Наследниците на Хаджи Иван Бечев са решили да увековечат славния си роднина. Направили инициативен комитет, след това ме 
поканиха мен. И така започнах барелефа на Бечев. С паметника на Сава Стратев или Келеш Саващо, както са му викали, историята е подобна. 
Инициативата идва от хората. Аз се включвам впоследствие, но работя с огромно удоволствие. Защото тези хора са личностите на родопското Възраждане.</p>
<p>- Имената на Хаджи Бечев и Келеш Саващо не присъстват често на различните тържества и чествания?</p>
<p>- Да, има много ярки личности, които имат значим принос в духовното пробуждане и народностно осъзнаване на българите, но не ги познаваме. 
Хаджи Иван Бечев например е родоначалникът на днешния Хаджииванов род в Устово. Корените на този род ни отвеждат в разломните времена на 17-и и 18-и век, 
когато част от родопските българи са били насилствено помохамеданчени. Той е сред най-дейните противници и на гъркоманството и ярък привърженик на 
самостоятелната българска църква. За Сава Стратев са писали доста краеведите. Фамилията му обаче никой не знае, защото навсякъде е изписан прякорът му - 
Келеш Саващо, което е израз на неговата смелост и упоритост в отстояването на българщината. Той е бил изкусен, знатен и търсен майстор бакърджия, но си 
спечелил слава и като човек, който милее за народните работи. Пет години в края на 19-и век той е бил мухтар (кмет) на Устово. Той е първият управник, 
който се е противопоставил на Ксантийската митрополия, когато е искала да повиши владиш-ките данъци. Нечувана дързост е проявил, когато се опънал на гръцкия 
владика Милетий, за да се пребори за оцеляването и спасяването на българското в планината. Той открито е заявил: „Християните в Родопите са българи и не 
искат да ги идентифицират като гърци!"". Келеш Саващо е инициатор за построяването на устовската църква ""Света Богородица"", изгражда ново училище, 
помага на първите учители.</p>
<p>- Пловдивчани  ви познават от двете изложби, където  показвахте основно абстрактни пластики.</p>
<p>- В рамките на Месеца на културата аз показах една експозиция в градинката пред община ""Север"". Тази изложба нарекох юбилейна във връзка със 70-ата 
ми годишнина. След това от новотел ""Пловдив"" ме поканиха да ситуирам работите си край алеите на комплекса. Аз правя абстрактни пластики и
портрети.Сред тях е портретът на една въз рожденска баба от Копривщица, който прави голямо впечатление. Така че тази тема ми е интересна и често
си работя за собствено удоволствие.
<p><STRONG><BR>Интервю на Евелина ВЕЛИЧКОВА</STRONG></p>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                //****************************************
                e = new MediaEvent()
                {
                    EventDate = new DateTime(1999, 09, 13),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 3,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MediaEventDetails = new List<MediaEventDetail>()
                };

                _context.MediaEvents.Add(e);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = @"<STRONG>
България - изложба - Брюксел<br>
Изложба на българско изкуство бе открита в Европейския парламент в Брюксел<br>
Брюксел, 25 март /БТА/<BR></STRONG>",
                    Body = @"В сградата на Европейския парламент /ЕП/ в Брюксел бе открита изложба на българско изящно изкуство под наслов ""България,
                    цвете от букета на Европа"". Това съобщи на БТА канцеларията на члена на ЕП Димитриос Кулурианос.<br>
Експозицията бе организирана по инициатива на живеещи в Брюксел българи и под патронажа на Хосе Мария Хил - Роблес,
                    председател от страна на Европейския парламент на Съвместния парламентарен комитет ЕС - България,
                    и на члена на парламента Димитриос Кулурианос.В словата си на церемонията по откриването те оцениха високо приноса на България в европейската култура.На тържеството присъства и посланикът на Република България в Европейския съюз Станислав Даскалов.<br>
Изложбата включва творби на скулптора Тодор Азманов и на художниците Никола Манев и Таньо Митев.Централно място сред експонатите заема мраморна женска глава с две лица,
                    символизираща източната и западната половина на единна Европа. / Ружица Угринова /<br><STRONG>/ КЛ /</STRONG>
"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = @"<STRONG>
България - изложба - Брюксел<br>
Изложба на българско изкуство бе открита в Европейския парламент в Брюксел<br>
Брюксел, 25 март /БТА/<BR></STRONG>",
                    Body = @"В сградата на Европейския парламент /ЕП/ в Брюксел бе открита изложба на българско изящно изкуство под наслов ""България,
                    цвете от букета на Европа"". Това съобщи на БТА канцеларията на члена на ЕП Димитриос Кулурианос.<br>
Експозицията бе организирана по инициатива на живеещи в Брюксел българи и под патронажа на Хосе Мария Хил - Роблес,
                    председател от страна на Европейския парламент на Съвместния парламентарен комитет ЕС - България,
                    и на члена на парламента Димитриос Кулурианос.В словата си на церемонията по откриването те оцениха високо приноса на България в европейската култура.На тържеството присъства и посланикът на Република България в Европейския съюз Станислав Даскалов.<br>
Изложбата включва творби на скулптора Тодор Азманов и на художниците Никола Манев и Таньо Митев.Централно място сред експонатите заема мраморна женска глава с две лица,
                    символизираща източната и западната половина на единна Европа. / Ружица Угринова /<br><STRONG>/ КЛ /</STRONG>
"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = @"<STRONG>
България - изложба - Брюксел<br>
Изложба на българско изкуство бе открита в Европейския парламент в Брюксел<br>
Брюксел, 25 март /БТА/<BR></STRONG>",
                    Body = @"В сградата на Европейския парламент /ЕП/ в Брюксел бе открита изложба на българско изящно изкуство под наслов ""България,
                    цвете от букета на Европа"". Това съобщи на БТА канцеларията на члена на ЕП Димитриос Кулурианос.<br>
Експозицията бе организирана по инициатива на живеещи в Брюксел българи и под патронажа на Хосе Мария Хил - Роблес,
                    председател от страна на Европейския парламент на Съвместния парламентарен комитет ЕС - България,
                    и на члена на парламента Димитриос Кулурианос.В словата си на церемонията по откриването те оцениха високо приноса на България в европейската култура.На тържеството присъства и посланикът на Република България в Европейския съюз Станислав Даскалов.<br>
Изложбата включва творби на скулптора Тодор Азманов и на художниците Никола Манев и Таньо Митев.Централно място сред експонатите заема мраморна женска глава с две лица,
                    символизираща източната и западната половина на единна Европа. / Ружица Угринова /<br><STRONG>/ КЛ /</STRONG>
"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                //****************************************
                e = new MediaEvent()
                {
                    EventDate = new DateTime(1999, 09, 13),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 4,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MediaEventDetails = new List<MediaEventDetail>()
                };

                _context.MediaEvents.Add(e);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = @"<P><STRONG>""Bulgaria, a Flower in the Bouquet of Europe ""</STRONG></P>
      <P><STRONG>Exhibition of Bulgarian artists at the European 
      Parliament,<BR><U>
24 March - 4 April, 
      2003<BR></U></STRONG>
     <br>",
                    Body = @"""<STRONG><EM>If we had to start all over again, I would begin with 
      culture</EM></STRONG>
             "",<br>
Jean Monet famously remarked about the construction of the European Community.<br>
The initiative of three Bulgarian artists - the sculptor Todor Azmanov, and the painters Tano Mitev and Nikola Manev - is a reminder that, while Bulgaria is looking forward to its future membership of the European Union, it undoubtedly already has its place in the European family, above all, perhaps, through its culture.<br>
Placed at the European cross-road between East and West, Bulgaria has nurtured an astounding amalgam of spirituality and creativity throughout its a 13 centuries of political existence. Its cultural heritage, nourished by an array of a traditions - from the legacy of the ancient Thracians, Greeks, and Romans, ; through that of the Southern Slav, as well as Middle Eastern and Asian cultures, a places Bulgaria equally at the heart of Europe's cultural past as in its vigorous future.<br>
In recent years Bulgaria has made a significant contribution to the stability I in the Balkans, by unfaltering and successful democratization, as well as by setting I an example of ethnic and religious pluralism within its own diverse polity.<br>
This exhibition is one of the events anticipating the 
      celebration of the Schuman's day, the father-founder of Europe, and will 
      prompt us to remember the high idealism which drove his project of united 
      and peaceful Europe.</P>
      <P><STRONG>&lt;bg&gt;</STRONG></P>
      <P>
Патрони на излозкбата бяха <EM>г-н Хосе Мария Хил 
      Роблес</EM>, председател на Европейската парламентарна делегация към 
      съвместния парламентарен комитет ЕС - България /и бивш президент на 
      Европейския парламент/ и <EM>г-н Димитриос Кулурианос</EM>
                              , Евродепутат и бивш финансов министър на Гърция.<br>
На откриването 
      на изложбата присъствуваха около 200 гости - депутати от Европарламента и 
      служители в Европейските институции в Брюксел /Достъпът до Парламента е 
      ограничен за външни лица/, директорите на консултантски центрове, свързани 
      с Европейската интеграция /<EM>Г-н Семинаторс</EM>, директор на Института 
      за Международни отношения и г-н Антоан, директор на Института по 
      Европейски изследвания/, официални лица от българските дипломатически 
      мисии в Брюксел и директорът на Българския отдел в ЕвроКомисията - 
      <EM>Мартен Юнг Олсен</EM>
                                                                      .<br>
Централната творба на 
      излозкбата беше мраморна скулптора с две женски лица с наименование 
      ""<STRONG><EM>Изток-Запад. Една Европа</EM></STRONG>
              "".<br>
На откриването присъствуваше и скулптора 
      <EM>Азманов.</EM>
     <br>
Изложбата се състоя в централния хол на парламента.<br>
На тържеството присъстваха и 
      посланникът на, Република България 8 Европейския съюз - <EM>Станислав 
      Даскалов</EM> и културното аташе - <EM>Евгени Стойчев</EM>
       
                 
       .</P>
      <P>
При откриването речи изнесоха <EM>г-н Хил Роблес, 
      г-н Кулурианос и г-н Станислав Даскалов</EM>
            , посланик на Бълзария в Европейския Съюз.<br><EM>Хил Роблес </EM>
  изтъкна, че това е първата по рода си инициатива на представяне на бълзарско изкуство в Европейския Парламент.<br><EM>Димитриос Кулурианос 
      </EM>
  говори с подчертана любов към България. ""Нашите страни /България и Гърция/ имат една особеност - ние произвеждаме повече култура, отколкото можем да консумираме. Време е да изнасяме към останалата част на Европа"".<br><EM>Господин Даскалов</EM>
 , правейки алюзия към мотото на 
      изложбата, каза: ""Ако България е цвете в букета на Европа, тя е неизменно 
      роза. А както е известно, розата има бодли. В същността на розата е 
      мъдростта, че към всяко добро нещо пътят е труден. Пътят на България към 
      Европейския модел на демокрация не беше лесен, но резултатите си 
      заслужават усилията"".</P>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = @"<P><STRONG>""Bulgaria, a Flower in the Bouquet of Europe ""</STRONG></P>
      <P><STRONG>Exhibition of Bulgarian artists at the European 
      Parliament,<BR><U>
24 March - 4 April, 
      2003<BR></U></STRONG>
     <br>",
                    Body = @"""<STRONG><EM>If we had to start all over again, I would begin with 
      culture</EM></STRONG>
             "",<br>
Jean Monet famously remarked about the construction of the European Community.<br>
The initiative of three Bulgarian artists - the sculptor Todor Azmanov, and the painters Tano Mitev and Nikola Manev - is a reminder that, while Bulgaria is looking forward to its future membership of the European Union, it undoubtedly already has its place in the European family, above all, perhaps, through its culture.<br>
Placed at the European cross-road between East and West, Bulgaria has nurtured an astounding amalgam of spirituality and creativity throughout its a 13 centuries of political existence. Its cultural heritage, nourished by an array of a traditions - from the legacy of the ancient Thracians, Greeks, and Romans, ; through that of the Southern Slav, as well as Middle Eastern and Asian cultures, a places Bulgaria equally at the heart of Europe's cultural past as in its vigorous future.<br>
In recent years Bulgaria has made a significant contribution to the stability I in the Balkans, by unfaltering and successful democratization, as well as by setting I an example of ethnic and religious pluralism within its own diverse polity.<br>
This exhibition is one of the events anticipating the 
      celebration of the Schuman's day, the father-founder of Europe, and will 
      prompt us to remember the high idealism which drove his project of united 
      and peaceful Europe.</P>
      <P><STRONG>&lt;bg&gt;</STRONG></P>
      <P>
Патрони на излозкбата бяха <EM>г-н Хосе Мария Хил 
      Роблес</EM>, председател на Европейската парламентарна делегация към 
      съвместния парламентарен комитет ЕС - България /и бивш президент на 
      Европейския парламент/ и <EM>г-н Димитриос Кулурианос</EM>
                              , Евродепутат и бивш финансов министър на Гърция.<br>
На откриването 
      на изложбата присъствуваха около 200 гости - депутати от Европарламента и 
      служители в Европейските институции в Брюксел /Достъпът до Парламента е 
      ограничен за външни лица/, директорите на консултантски центрове, свързани 
      с Европейската интеграция /<EM>Г-н Семинаторс</EM>, директор на Института 
      за Международни отношения и г-н Антоан, директор на Института по 
      Европейски изследвания/, официални лица от българските дипломатически 
      мисии в Брюксел и директорът на Българския отдел в ЕвроКомисията - 
      <EM>Мартен Юнг Олсен</EM>
                                                                      .<br>
Централната творба на 
      излозкбата беше мраморна скулптора с две женски лица с наименование 
      ""<STRONG><EM>Изток-Запад. Една Европа</EM></STRONG>
              "".<br>
На откриването присъствуваше и скулптора 
      <EM>Азманов.</EM>
     <br>
Изложбата се състоя в централния хол на парламента.<br>
На тържеството присъстваха и 
      посланникът на, Република България 8 Европейския съюз - <EM>Станислав 
      Даскалов</EM> и културното аташе - <EM>Евгени Стойчев</EM>
       
                 
       .</P>
      <P>
При откриването речи изнесоха <EM>г-н Хил Роблес, 
      г-н Кулурианос и г-н Станислав Даскалов</EM>
            , посланик на Бълзария в Европейския Съюз.<br><EM>Хил Роблес </EM>
  изтъкна, че това е първата по рода си инициатива на представяне на бълзарско изкуство в Европейския Парламент.<br><EM>Димитриос Кулурианос 
      </EM>
  говори с подчертана любов към България. ""Нашите страни /България и Гърция/ имат една особеност - ние произвеждаме повече култура, отколкото можем да консумираме. Време е да изнасяме към останалата част на Европа"".<br><EM>Господин Даскалов</EM>
 , правейки алюзия към мотото на 
      изложбата, каза: ""Ако България е цвете в букета на Европа, тя е неизменно 
      роза. А както е известно, розата има бодли. В същността на розата е 
      мъдростта, че към всяко добро нещо пътят е труден. Пътят на България към 
      Европейския модел на демокрация не беше лесен, но резултатите си 
      заслужават усилията"".</P>"
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = @"ПРЕВОД ИДЕЙНА ПЛАТфОРМА ""БЪЛГАРИЯ, ЦВЕТЕ В БУКЕТА НА ЕВРОПА""<br>
Изложба на български художници в Европейския 
      Парламент, 24 март - 4 април, 2003<BR></STRONG>",
                    Body = @"""Ако трябваше да започнем всичко отначало, аз бих започнал с културата"", заявил Жан Моне, един от основателите на Европейския съюз, относно Европейската интеграция.<br>
Инициативата на трима български художника - скулпторът Тодор Азманов, и художниците Таньо Митев и Никола Манев - напомня, че докато Бълзария очаква присъединяването си в Европейския съЬз, тя вече безспорно принадлежи към Европейското семейство, преди всичко може би, чрез културата си.<br>
Разположена на Европейския кръстопът между Изтока и Запада, България е развила амалгама от духовност и изобретателност отвъд 13 вековното си политическо съществуване. Нейното културно наследство, захранвано от множество традиции - от това на древните Тракийци, Гърци и Римляни, през наследството на Южните славяни, както на Близко Източните и Азиатските култури, слага България както в сърцето на Европейското културно минало, така и в центъра на динамичното бъдеще на Европа.<br>
През последните години Бълзария допринесе съществено за стабилността на Балканите, чрез непоколебимата си демократизация, както и поставяйки пример за етнически и религиозен плурализъм.<br>
Тази изложба е едно от събитията, чрез 
      които тази година се чества денят на <STRONG>Роберт Шуман - 9 
      май</STRONG>, основателят на Европейската общност, и ни кара да си спомним 
      великият идеализъм, който движи проекта на обединена 
и мирна Европа."
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                //****************************************
                e = new MediaEvent()
                {
                    EventDate = new DateTime(1999, 09, 13),
                    CreatedDateTime = DateTime.UtcNow,
                    Order = 5,
                    ExpireDateTime = DateTime.UtcNow.AddYears(100),
                    MediaEventDetails = new List<MediaEventDetail>()
                };

                _context.MediaEvents.Add(e);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "EN").Id,
                    Title = "SALLE DES 4 COEONNES: Sculpture bulgare avec Azmanov Todor",
                    Body = @"Dans le cadre du jumelage Alger-Sofia, une exposition de sculpture a eтe inauguree mardi soir par l'ambas-sadeur de Bulgaria a Alger en presence du president de l'APC d'Alger et de personnalites algeriennes et bulga-res.<br>
Cette exgpsition presente lеs oeu-vres du sculpteur bulgare Todor Azmanov qui a rendu hommage a nos martyrs et a de grands homines com-me l'Emir Abdelkader, le Cheikh Ibn Badis, le Cheikh Bachir Ibrahimi et a notre president Houari  Bournediene.<br>
L'artiste a par ailleurs sculpte des tetes de citoyens bulgares et algeriens typiques, anonymes, afin de fixer une expression ou un profil qui ont frappe.<br>
Son regard inspire Ces sculptures sont en platre ou en bois, travaillees avec talent et minutie, polies et poncees, soignees detail par detail, para-chevees.<br>
Et lorsque le visiteur fait le tour de la Galerie des 4 Colonnes, il rencontre des visages graves et quelquo peu mysterieux, Aissat-Idir, Abane Ramdane, Ben M'hidi Larbi et bien d'autres de nos heros de la lutte de liberation.<br>
Ce meme visiteur fait la connais-sance de poetes et de peintres bulgares, dont les traits ont ete fidelement reproduits par leur concitoyen Azmanov,<br>
Il est a noter que cette exposition interessanfte, restera ouverte jus-qu'au 25 juin.<br>
* Toujours a la Galerie des 4 Colonnes, signalons que 
      demain aura Heu a 18 h 30, La vernissage de l'exposition photographique « 
      Horizons canadiens » Lje public est convie 
a cette manifestation."
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "FR").Id,
                    Title = "SALLE DES 4 COEONNES: Sculpture bulgare avec Azmanov Todor",
                    Body = @"Dans le cadre du jumelage Alger-Sofia, une exposition de sculpture a eтe inauguree mardi soir par l'ambas-sadeur de Bulgaria a Alger en presence du president de l'APC d'Alger et de personnalites algeriennes et bulga-res.<br>
Cette exgpsition presente lеs oeu-vres du sculpteur bulgare Todor Azmanov qui a rendu hommage a nos martyrs et a de grands homines com-me l'Emir Abdelkader, le Cheikh Ibn Badis, le Cheikh Bachir Ibrahimi et a notre president Houari  Bournediene.<br>
L'artiste a par ailleurs sculpte des tetes de citoyens bulgares et algeriens typiques, anonymes, afin de fixer une expression ou un profil qui ont frappe.<br>
Son regard inspire Ces sculptures sont en platre ou en bois, travaillees avec talent et minutie, polies et poncees, soignees detail par detail, para-chevees.<br>
Et lorsque le visiteur fait le tour de la Galerie des 4 Colonnes, il rencontre des visages graves et quelquo peu mysterieux, Aissat-Idir, Abane Ramdane, Ben M'hidi Larbi et bien d'autres de nos heros de la lutte de liberation.<br>
Ce meme visiteur fait la connais-sance de poetes et de peintres bulgares, dont les traits ont ete fidelement reproduits par leur concitoyen Azmanov,<br>
Il est a noter que cette exposition interessanfte, restera ouverte jus-qu'au 25 juin.<br>
* Toujours a la Galerie des 4 Colonnes, signalons que 
      demain aura Heu a 18 h 30, La vernissage de l'exposition photographique « 
      Horizons canadiens » Lje public est convie 
a cette manifestation."
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);

                eventDetail = new MediaEventDetail()
                {
                    LanguageId = _context.Languages.First(p => p.ShortDisplay == "BG").Id,
                    Title = "SALLE DES 4 COEONNES: Sculpture bulgare avec Azmanov Todor",
                    Body = @"Dans le cadre du jumelage Alger-Sofia, une exposition de sculpture a eтe inauguree mardi soir par l'ambas-sadeur de Bulgaria a Alger en presence du president de l'APC d'Alger et de personnalites algeriennes et bulga-res.<br>
Cette exgpsition presente lеs oeu-vres du sculpteur bulgare Todor Azmanov qui a rendu hommage a nos martyrs et a de grands homines com-me l'Emir Abdelkader, le Cheikh Ibn Badis, le Cheikh Bachir Ibrahimi et a notre president Houari  Bournediene.<br>
L'artiste a par ailleurs sculpte des tetes de citoyens bulgares et algeriens typiques, anonymes, afin de fixer une expression ou un profil qui ont frappe.<br>
Son regard inspire Ces sculptures sont en platre ou en bois, travaillees avec talent et minutie, polies et poncees, soignees detail par detail, para-chevees.<br>
Et lorsque le visiteur fait le tour de la Galerie des 4 Colonnes, il rencontre des visages graves et quelquo peu mysterieux, Aissat-Idir, Abane Ramdane, Ben M'hidi Larbi et bien d'autres de nos heros de la lutte de liberation.<br>
Ce meme visiteur fait la connais-sance de poetes et de peintres bulgares, dont les traits ont ete fidelement reproduits par leur concitoyen Azmanov,<br>
Il est a noter que cette exposition interessanfte, restera ouverte jus-qu'au 25 juin.<br>
* Toujours a la Galerie des 4 Colonnes, signalons que 
      demain aura Heu a 18 h 30, La vernissage de l'exposition photographique « 
      Horizons canadiens » Lje public est convie 
a cette manifestation."
                };

                e.MediaEventDetails.Add(eventDetail);
                _context.MediaEventDetails.Add(eventDetail);



                // Save data
                _context.SaveChanges();
            }
            #endregion
        }
    }
}

