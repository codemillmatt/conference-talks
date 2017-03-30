using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices.WindowsRuntime;
using Foodie.Abstractions;

namespace Foodie
{
    public class EditRecipeViewModel : BaseRecipeViewModel
    {
        INavigation _nav;
        bool _isNewRecipe = true;

        public EditRecipeViewModel(Recipe recipe, INavigation nav) : this(nav)
        {
            Recipe = recipe;
            _isNewRecipe = false;

            RecipeName = Recipe.RecipeName;
            PreparationTime = Recipe.PreparationTime;
            CookTime = Recipe.CookTime;
            NumberOfServings = Recipe.NumberOfServings;
            WillMakeAgain = Recipe.WillMakeAgain;
            Difficulty = Recipe.Difficulty;
            MealType = Recipe.MealType;
            Ingredients = Recipe.Ingredients;
            Directions = Recipe.Directions;
            IsRecommended = Recipe.IsRecommended;
            ImageName = Recipe.ImageName;
        }

        public EditRecipeViewModel(INavigation nav)
        {
            _nav = nav;
        }

        Recipe Recipe { get; set; }

        ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new Command(async () =>
                    {
                        // If new recipe - it's being displayed modally
                        if (_isNewRecipe)
                        {
                            await _nav.PopModalAsync(true);
                        }
                        else
                        {
                            await _nav.PopAsync(true);
                        }
                    });
                }
                return _cancelCommand;
            }
        }

        ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(async () =>
                    {                        
                        var recipeToSave = new Recipe
                        {
                            CookTime = CookTime,
                            Difficulty = Difficulty,
                            Directions = Directions,
                            ImageName = ImageName,
                            Ingredients = Ingredients,
                            IsRecommended = IsRecommended,
                            MealType = MealType,
                            WillMakeAgain = WillMakeAgain,
                            NumberOfServings = NumberOfServings,
                            PreparationTime = PreparationTime,
                            RecipeName = RecipeName
                        };

						var dataSvc = DependencyService.Get<IAzureService>(DependencyFetchTarget.GlobalInstance);

                        if (_isNewRecipe)
                        {
                            // difficulty and meal type will not be set if the picker never changed
                            recipeToSave.Difficulty = recipeToSave.Difficulty ?? Foodie.Difficulty.Easy;
                            recipeToSave.MealType = recipeToSave.MealType ?? Foodie.MealType.Breakfast;

                            recipeToSave.Id = Guid.NewGuid().ToString();

							await dataSvc.InsertRecipe(recipeToSave);
                            await _nav.PopModalAsync(true);
                        }
                        else
                        {
                            recipeToSave.Id = Recipe.Id;
							await dataSvc.UpdateRecipe(recipeToSave);
                            await _nav.PopAsync(true);
                        }

                        MessagingCenter.Send(this, RecipeSavedMessage);
                    });
                }
                return _saveCommand;
            }
        }
    }
}
