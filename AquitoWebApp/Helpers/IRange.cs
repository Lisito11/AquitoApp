using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoWebApp.Helpers {
    public interface IRange<T> {
        T Start { get; }
        T End { get; }
        bool WithInRange(T value);
        bool WithInRange(IRange<T> range);
    }
   
}
