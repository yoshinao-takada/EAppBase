@page Declare GUI interface
# Overview
An example of the GUI interfaces is described here.
The example is actually used in the example proect.
Please refer MainWindow.xaml.cs for more informaton.

# Code
Source 1: Interface definition
```
001    /// <summary>
002    /// The interface exported by MainWindow. External code accesses MainWindow via the
003    /// initerface. The interface does not contain anything directly related GUI;
004    /// e.g. Brush, Label, Thickness, etc.
005    /// </summary>
006    public interface IMainWindowExports
007    {
008        /// <summary>
009        /// This event triggers any external action by clicking the button at the bottom-left
010        /// of MainWindow.
011        /// </summary>
012        event RoutedEventHandler ButtonAction;
013
014        /// <summary>
015        /// Incremented or decremented by external code. UI elements in MainWindow are
016        /// automatically updated.
017        /// </summary>
018        int Counter { get; set; }
019    }
```
The example of an interface declaration is shown above, source 1.
There are several features.
1. Documentation is an important element in software development. Each interface must
be fully documented by XML documentation comment of C# standard format.
2. ButtonAction in line 012 declares event interface. Implementation details are
explained later.
3. Counter in line 018 declares a simple int type property. The setter implements
data binding like actions by usual simple coding but not indirect data binding
using INotityPropertyChanged interface. Our proposing way is simpler than the Microsoft
way using INotifyPropertyChanged or INotifyPropertyChanging.

# Implementing an event interface
Microsoft official document well describes in the article,
"[How to implement interface events (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-implement-interface-events)
".
The code shown in the article is a little bit overkill for a usual WPF application
run in single thread. Object locking is actually not needed for our purposes.
But of course, usulal multi-threaded application requires object locking.
But in such cases, applying WPF is more complicated, requiring indirect method calling
using object.invoke() method because WPF UIElement is not allowed accessed by
an object running in other threads.
