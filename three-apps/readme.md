# Creating Three Beautiful Apps at Once with Xamarin.Forms
### An Intro to Xamarin.Forms

Given at:
* Indy.Code() - March 30, 2017
* Chicago Code Camp - April 29, 2017
* MKEdotNET - September 9, 2017
* Prairie.Code() - September 28, 2017

## Abstract
You read that title correct – you can create an app for three different platforms all at once using Xamarin.Forms.

Xamarin.Forms has come a long way since the days of when its recommended use was for simple apps and prototyping only and in this session, I will show you the advances made and how to utilize them to create beautiful apps yourself. You will see the basic structure of a Xamarin.Forms app and how to use XAML and the built-in controls to create a UI. You’ll learn about the MVVM pattern and data binding so information can be presented and modified in the UI and app logic layer with ease. You’ll walk through accessing platform specific native controls – from XAML! At the end of this session – you’ll be able to create a beautiful app – make that three beautiful apps – with Xamarin.Forms.

## The Slides
[Here you go](https://www.slideshare.net/MatthewSoucoup/creating-3-beautiful-apps-at-once-intro-to-xamarinforms)

## Demos
1. ListViews and TableViews - A hello world demo, if you will, showing how to build up a simple list view. Note the `ItemTemplate`, `DataTemplate` and `TextCell` - which displays the data. The edit page recieves the data. Note the `TableView`. The `Root` holds the entire view, while `Section`s are individual sections that are grouped by related data. `Cells` will take in data. The detail page display data. It uses a `Grid`, which extremely useful for displaying data in a 2-Dimensional layout. Where the controls are laid out within the `Grid` are actually specified within the control's definition instead of the `Grid`.

2. MVVM - `INotifyPropertyChanged` is the interface used for ViewModels to notify the View of when any data has changed. When data changes in the views, the same interface is used to alert the ViewModel. `Command`s are used to notify the ViewModel that an event has occured within the View.

3. Messaging Center and native views - use the messaging center to communicate between classes that do not know anything about each other. By sending and subscribing to messages you can send messages without any data or messages with objects. XAML also supports native views - or embedding 100% iOS or Android views into the core project. When compiled, the other operating systems will ignore the views. The properties of the native views can even be data bound!

