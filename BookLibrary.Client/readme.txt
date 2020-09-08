1) �������� �������:
    - DAL - �������� ����� - ���� ������ �� ������� �� �� ��������
    - BLL - ����� ����� - ���� ������ ���� ���������� ���� ��������
            ��������� �����
    - Client - WPF project

2) �������� ��� DAL: ��������� �������, �������� �� ����������
   ���������� ����������� CRUD-���������� �� ���� ��

3) BLL: 
   ��������� �����: �������� ��������� - � ���� ���� ���������

4) �볺��: ��������� �� �볺�� ��������� �� �����, �� �������� CRUD �� �볺��
   ������������ �� �볺�� ���� ��������� �� ������� connection string

______________________________________________________________________________________

5) ��������� DTO - Data Transfer Object - ��'���, ����������� ��� �������� �� ������ - �� BLL

6) ���������� AutoMapper - ��� ������������ ������ � Object � ObjectDTO � �������
        - ��������� ���� �� �������� Profile, � ����������� ������� CreateMap()
        - ���� ����� ���� �� ���� ����������, �� ��������� ��� ������� ������������ ����� ����, 
        ���� � - �� ���� "������� �����" - �������� ����� � ForMember()
          CreateMap<Book, BookDTO>()
        //    Author = item.Author.Name,
                .ForMember(x=>x.Author, opt=>opt.MapFrom(x=>x.Author.Name))
                .ForMember(x=>x.Genre, opt=>opt.MapFrom(x=>x.Genre.Name));

_______________________________________________________________________________________

7) ���� � ������ 5-�� ������� ������ ��'����� ����������� ����� �����������, ���������:
 public EFRepository(DbContext _context)
        {
            context = _context;
        }
�� ������� ������� ������� �������� (���������� Autofac �� �볺�� �� ���� �������������� � App.xaml.cs)

8) ��� ����� ������ override OnStartup(...)
 �� �������� ��������� ����. ���������:
  builder.RegisterType<BookService>().As<IBookService>();
  �� ����쳺���� ��: ����� new BookService() ���� ���� ������� IBookService

9) ��� �� ��������� ������� �������� ������ Resolve()
�� WPF ������ ���: 
            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.ShowDialog();
            }

10) �������� �� ��������� � ���� ������������ �������:
    var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
            builder.RegisterInstance(config.CreateMapper());

11) ����� ��'���� ������ "��������" �������� ���������� ������:
   IMapper mapper;
   ...
   ctor(..., IMapper _mapper)
   {
    ...
    mapper = _mapper;
    ...
   }
   var model = mapper.Map<ICollection<BookDTO>>(books);