using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pokedex.Converter {
    public class PokemonColor : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            switch (value.ToString()) {
                case "normal":
                    return "#a8a878";
                case "fighting":
                    return "#c03028";
                case "flying":
                    return "#a890f0";
                case "poison":
                    return "#a040a0";
                case "ground":
                    return "#e0c068";
                case "rock":
                    return "#b8a038";
                case "bug":
                    return "#a8b820";
                case "fire":
                    return "#f08030";
                case "water":
                    return "#6890f0";
                case "grass":
                    return "#78c850";
                case "electric":
                    return "#f8d030";
                case "psychic":
                    return "#f85888";
                case "ice":
                    return "#98d8d8";
                case "dragon":
                    return "#7038f8";
                case "ghost":
                    return "#705898";
                case "dark":
                    return "#705848";
                case "steel":
                    return "#b8b8d0";
                case "fairy":
                    return "#f39aae";
            }
            return "#EB5757";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return "#EB5757";
        }
    }
}
