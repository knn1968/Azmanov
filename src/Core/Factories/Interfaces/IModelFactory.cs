using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Factories.Interfaces
{
    public interface IModelFactory<TInput, TOutput>
        where TInput : class, new()
        where TOutput : class, new()
    {
        //TOutput CreateInstance(TInput input);
        TOutput CreateInstance(TInput input, string languageShortDisplay = null);
        //IEnumerable<TOutput> CreateList(IEnumerable<TInput> input);
        IEnumerable<TOutput> CreateList(IEnumerable<TInput> input, string languageShortDisplay = null);
    }
}
