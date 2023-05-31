using AutoMapper;
using DevGames.Application.Interfaces;
using DevGames.Application.ViewModel;
using DevGames.Domain.Entities;
using DevGames.Domain.Interfaces;
using DevGames.Domain.Shared.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Application.Services
{
    public class ClientAppService : BaseService, IClientAppService
    {
        protected readonly IClientRepository _repository;
        protected readonly IMapper _mapper;

        public ClientAppService(IClientRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientViewModel> AddAsync(ClientViewModel viewModel)
        {
            Client domain = _mapper.Map<Client>(viewModel);
            domain = await _repository.AddAsync(domain);
            Commit();

            ClientViewModel viewModelReturn = _mapper.Map<ClientViewModel>(domain);
            return viewModelReturn;
        }

        public ClientViewModel GetById(Guid id)
        {
            var domain = _repository.GetById(id);
            var viewModel = _mapper.Map<ClientViewModel>(domain);
            return viewModel;
        }

        public async Task<ClientViewModel> GetByIdAsync(Guid id)
        {
            var domain = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<ClientViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Client, bool>> expression)
        {
            _repository.Remove(expression);
            Commit();
        }

        public IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> predicate)
        {
            var domain = _repository.Search(predicate);
            var viewModels = _mapper.Map<IEnumerable<ClientViewModel>>(domain);
            return viewModels;
        }

        public IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> predicate, int pageNumber, int pageSize)
        {
           var domain = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<ClientViewModel>>(domain);
            return viewModels;
        }

        public async Task<IEnumerable<ClientViewModel>> SearchAsync(Expression<Func<Client, bool>> predicate)
        {
            var domain = await _repository.SearchAsync(predicate);
            var viewModels = _mapper.Map<IEnumerable<ClientViewModel>>(domain);
            return viewModels;
        }

        public ClientViewModel Update(ClientViewModel viewModel)
        {
            var domain = _mapper.Map<Client>(viewModel);
            domain = _repository.Update(domain);
            Commit();
            ClientViewModel viewModelReturn = _mapper.Map<ClientViewModel>(domain);
            return viewModelReturn;
        }
    }
}
