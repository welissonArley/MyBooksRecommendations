using AutoMapper;
using MyBooksRecommendations.Communication.Response;
using MyBooksRecommendations.Domain.Repository;
using MyBooksRecommendations.Domain.ValueObject;

namespace MyBooksRecommendations.Application.UseCases.Book.Get
{
    public class GetBookUseCase : IGetBookUseCase
    {
        private IBookReadOnlyRepository _repository;
        private IMapper _mapper;

        public GetBookUseCase(IMapper mapper, IBookReadOnlyRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IList<ResponseBookJson> Execute(BookFilter? filter = null)
        {
            var response = _repository.GetAllBooks(filter).OrderBy(c => c.Type).ThenBy(c => c.Status).ThenBy(c => c.Title);

            return _mapper.Map<IList<ResponseBookJson>>(response);
        }
    }
}
