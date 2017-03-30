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

		public EditRecipeViewModel(SecureRecipe recipe, INavigation nav) : this(nav)
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

			Recipe = new SecureRecipe();
			RecipeName = "";
			PreparationTime = "";
			CookTime = "";
			NumberOfServings = 0;
			WillMakeAgain = false;
			Difficulty = Foodie.Difficulty.Easy;
			MealType = Foodie.MealType.Breakfast;
			Ingredients = "";
			IsRecommended = false;
			ImageName = GenerateImageName();
		}

		string GenerateImageName()
		{
			string imageName = "";
			var seed = new Random().Next(0, 5);

			switch (seed)
			{
				case 0:
					imageName = "blueberry-muffins.jpg";
					break;
				case 1:
					imageName = "burger.jpg";
					break;
				case 2:
					imageName = "eggs-benedict.jpg";
					break;
				case 3:
					imageName = "fresh-food.jpg";
					break;
				case 4:
					imageName = "ham.jpg";
					break;
				default:
					imageName = "potato-salad.jpg";
					break;
			}

			return imageName;
		}

		SecureRecipe Recipe { get; set; }

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
						var dataSvc = DependencyService.Get<IAzureService>(DependencyFetchTarget.GlobalInstance);

						var recipeToSave = new SecureRecipe
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

						var recipeTable = await dataSvc.GetTable<SecureRecipe>();

						if (_isNewRecipe)
						{
							// difficulty and meal type will not be set if the picker never changed
							recipeToSave.Difficulty = recipeToSave.Difficulty ?? Foodie.Difficulty.Easy;
							recipeToSave.MealType = recipeToSave.MealType ?? Foodie.MealType.Breakfast;

							recipeToSave.Id = Guid.NewGuid().ToString();

							var newRecipe = await recipeTable.Insert(recipeToSave);
							await _nav.PopModalAsync(true);
						}
						else
						{
							recipeToSave.Id = Recipe.Id;
							var newRecipe = await recipeTable.Update(recipeToSave);
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
