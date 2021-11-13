using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class AppViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, string> MyCommand { get; }
        public AppViewModel()
        {
            MyCommand = ReactiveCommand.CreateFromObservable(MyCommandHandler);
        }

        public IObservable<string> MyCommandHandler()
        {
            return Observable.Return("Hello World!");
        }
    }
}
