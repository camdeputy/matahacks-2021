
/**
 * Create a function to calculate the number of trees needed 
 * to offset the total co2 emmision based on what the user chose
 * from the dropdown option
 * myFunction ex.falcon9:425 -> convert to # trees
 */

const rocket_info = {
	falcon9: "425",
	titan2: "36", 
	soyuzfg: "243",
	atlas22: "259",
	spaceshuttle: "443",
	sls: "538",
	starship: "2683",
}

function myFunction(rocket_name) {
	if(rocket_name in rocket_info){
		var co2_emission = rocket_info[rocket_name]
	}

	/**
	 * Source: https://www.arborday.org/trees/treefacts/
	 * a single tree offsets ~48lbs of carbon a year
	 */
	
	var single_tree = 0.0217724
	var total_trees = Math.ceil(co2_emission / single_tree)

	var output = `It would take the ${rocket_name} rocket approximately ${total_trees} trees 1 year to offset the carbon emissions produced from launch `
	document.getElementById("text-trees").innerHTML=output

}

