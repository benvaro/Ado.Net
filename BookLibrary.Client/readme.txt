1) Створити проекти:
    - DAL - бібліотека класів - буде містити всі сутності БД та контекст
    - BLL - бізнес логіка - буде містити весь функціонал нашої програми
            Бібліотека класів
    - Client - WPF project

2) Працюємо над DAL: створюємо сутності, контекст та репозиторій
   Репозиторій представляє CRUD-функціонал до нашої БД

3) BLL: 
   Створюємо сервіс: спочатку інтерфейс - а потім його реалізацію

4) Клієнт: Створюємо на клієнті посилання на сервіс, та реалізуємо CRUD на клієнті
   Установлюємо на клієнт ентіті фреймворк та копіюємо connection string

______________________________________________________________________________________

5) Створюємо DTO - Data Transfer Object - об'єкт, призначений для передачі між рівнями - на BLL

6) Інсталюємо AutoMapper - для автоатизації мапінгу з Object в ObjectDTO і навпаки
        - Створюємо клас та наслідуємо Profile, в конструкторі описуємо CreateMap()
        - Якщо назви полів та типи співпадають, то автомапер сам зробить перетворення таких полів, 
        якщо ні - то маємо "навчити мапер" - вказавши опції в ForMember()
          CreateMap<Book, BookDTO>()
        //    Author = item.Author.Name,
                .ForMember(x=>x.Author, opt=>opt.MapFrom(x=>x.Author.Name))
                .ForMember(x=>x.Genre, opt=>opt.MapFrom(x=>x.Genre.Name));

_______________________________________________________________________________________

7) Якщо в перших 5-ти пунктах робили ін'єкції залежностей через конструктор, наприклад:
 public EFRepository(DbContext _context)
        {
            context = _context;
        }
то потрібно зробити інверсію контролю (встановити Autofac на клієнт та його сконфігурувати в App.xaml.cs)

8) Для цього пишемо override OnStartup(...)
 та реєструємо залежності типів. Наприклад:
  builder.RegisterType<BookService>().As<IBookService>();
  Що розуміється як: Видай new BookService() коли тебе просять IBookService

9) Далі ці залежності вирішуємо викликом методу Resolve()
На WPF робимо так: 
            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.ShowDialog();
            }

10) Реєструємо ще автомапер в файлі конфігурації автофак:
    var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
            builder.RegisterInstance(config.CreateMapper());

11) Надалі об'єкти будуть "мапитись" викликом наступного методу:
   IMapper mapper;
   ...
   ctor(..., IMapper _mapper)
   {
    ...
    mapper = _mapper;
    ...
   }
   var model = mapper.Map<ICollection<BookDTO>>(books);