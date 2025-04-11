const express = require('express');
const app = express();

// Recipe data
const recipes = [
  {
    name: "Classic Spaghetti Carbonara",
    ingredients: [
      {
        name: "Spaghetti",
        description: "200g of dried pasta"
      },
      {
        name: "Pancetta",
        description: "150g, diced into small cubes"
      },
      {
        name: "Eggs",
        description: "2 whole eggs plus 2 egg yolks, at room temperature"
      },
      {
        name: "Parmesan Cheese",
        description: "50g, freshly grated"
      },
      {
        name: "Black Pepper",
        description: "Freshly ground, to taste"
      },
      {
        name: "Salt",
        description: "For pasta water and seasoning"
      }
    ]
  },
  {
    name: "Guacamole",
    ingredients: [
      {
        name: "Avocados",
        description: "3 ripe avocados, halved and pitted"
      },
      {
        name: "Lime",
        description: "1 lime, juiced"
      },
      {
        name: "Red Onion",
        description: "1/2 cup, finely diced"
      },
      {
        name: "Cilantro",
        description: "3 tablespoons, chopped fresh"
      },
      {
        name: "Tomato",
        description: "1 medium, diced"
      },
      {
        name: "Garlic",
        description: "1 clove, minced"
      },
      {
        name: "Salt",
        description: "To taste"
      }
    ]
  },
  {
    name: "Chicken Tikka Masala",
    ingredients: [
      {
        name: "Chicken Breast",
        description: "500g, cut into bite-sized pieces"
      },
      {
        name: "Yogurt",
        description: "1 cup, plain"
      },
      {
        name: "Lemon Juice",
        description: "2 tablespoons, freshly squeezed"
      },
      {
        name: "Garam Masala",
        description: "2 teaspoons, divided"
      },
      {
        name: "Tomato Sauce",
        description: "1 can (15 oz)"
      },
      {
        name: "Heavy Cream",
        description: "1 cup"
      },
      {
        name: "Garlic",
        description: "3 cloves, minced"
      },
      {
        name: "Ginger",
        description: "1 tablespoon, freshly grated"
      }
    ]
  },
  {
    name: "Green Smoothie Bowl",
    ingredients: [
      {
        name: "Spinach",
        description: "2 cups, fresh"
      },
      {
        name: "Banana",
        description: "1 frozen banana"
      },
      {
        name: "Mango",
        description: "1/2 cup, frozen chunks"
      },
      {
        name: "Almond Milk",
        description: "1/2 cup"
      },
      {
        name: "Chia Seeds",
        description: "1 tablespoon"
      },
      {
        name: "Honey",
        description: "1 teaspoon (optional)"
      }
    ]
  },
  {
    name: "Classic Beef Burger",
    ingredients: [
      {
        name: "Ground Beef",
        description: "500g, 80% lean"
      },
      {
        name: "Onion",
        description: "1/2 medium, finely grated"
      },
      {
        name: "Garlic",
        description: "2 cloves, minced"
      },
      {
        name: "Worcestershire Sauce",
        description: "1 tablespoon"
      },
      {
        name: "Salt",
        description: "1 teaspoon"
      },
      {
        name: "Black Pepper",
        description: "1/2 teaspoon, freshly ground"
      },
      {
        name: "Burger Buns",
        description: "4 buns, preferably brioche"
      }
    ]
  }
];

// Route for getting recipes
app.get('/recipes', (req, res) => {
  res.json({
    recipes: recipes
  });

  console.log("Request from:"+req.baseUrl)
});

// Start the server on port 8080
const PORT = 8080;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});