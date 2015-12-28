using Core;
using Core.Factories.Interfaces;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Paging
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Pager<TInput, TOutput> : IPager<TInput, TOutput>
        where TInput : class, new()
        where TOutput : class, IPageItem, new()
    {
        private int _pagesPerPageGroup;
        private int _itemsPerPage;
        private IPagingRepository<TInput> _repository;
        private IModelFactory<TInput, TOutput> _modelFactory;

        public Pager(
            IPagingRepository<TInput> repository, 
            IModelFactory<TInput, TOutput> modelFactory, 
            int itemsPerPage, 
            int pagesPerPageGroup)
        {

            _itemsPerPage = itemsPerPage;
            _pagesPerPageGroup = pagesPerPageGroup;
            _repository = repository;
            _modelFactory = modelFactory;

            if (itemsPerPage < 1 || pagesPerPageGroup < 1)
                throw new PagingException("Invalid Page Size");
        }
        public PagingResult<TOutput> GetPage(int page, string languageShortDisplay)
        {
            // Get count
            int sourceCount = _repository.GetCount();

            // Determine number of pages
            var totalNumberOfPages =
                sourceCount / _itemsPerPage + (sourceCount % _itemsPerPage > 0 ? 1 : 0);

            // Validate page
            if (page < 1 || (page > totalNumberOfPages && totalNumberOfPages > 0))
                throw new PagingException("Invalid Page");

            // Determine Current page items 
            var currentPageItems = _modelFactory.CreateList(_repository.GetPage(languageShortDisplay, _itemsPerPage * (page - 1), _itemsPerPage), languageShortDisplay);

            //Determine page group items
            var currentPageGroup = page / _pagesPerPageGroup + (page % _pagesPerPageGroup > 0 ? 1 : 0);

            List<int> currentPageGroupPageNumbers = new List<int>();
            for (int i = currentPageGroup * _pagesPerPageGroup - _pagesPerPageGroup + 1; i <= currentPageGroup * _pagesPerPageGroup && i <= totalNumberOfPages; i++)
            {
                currentPageGroupPageNumbers.Add(i);
            }

            // Determine next page
            int? nextPage = currentPageGroupPageNumbers.OrderBy(p => p).LastOrDefault() + 1;
            if (nextPage > totalNumberOfPages)
                nextPage = null;

            // Determine previous page
            int? previousPage = currentPageGroupPageNumbers.OrderBy(p => p).FirstOrDefault() - 1;
            if (previousPage < 1)
                previousPage = null;

            return new PagingResult<TOutput>()
            {
                CurrentPage = page,
                CurrentPageItems = currentPageItems,
                CurrentPageGroupPageNumbers = currentPageGroupPageNumbers,
                PreviousPage = previousPage,
                NextPage = nextPage
            };
        }
    }

}
