using Turn_base_battle_game;
int n = int.Parse(Console.ReadLine());
Unit []player = new Unit[n];
for(int i=0;i<n;i++){
    string[] inputs = Console.ReadLine().Split(' ');
    player[i] = new Unit(int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2]),
                         inputs[3], int.Parse(inputs[4]), int.Parse(inputs[5]), 
                         int.Parse(inputs[6]), int.Parse(inputs[7]));
                         //Max_hp, Attack_Power, Heal_Power, UnitName, 
                         //Criticle_Chance , Revive_Left, Attack_Speed , Base_Attack_Speed
}

int number_Of_players_Alive = n ;
while(number_Of_players_Alive>1){
    for(int i=0;i<n-1;i++){
        if(player[i].Alive == false) continue;
        string choice = Console.ReadLine();
        
        if(choice == "Purchase_Armour"){
            int []parameter = new int[2];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            parameter[1] = Convert.ToInt32(parameters_in_strings[1]);
            player[i].Purchase_Armour(parameter[0],parameter[1]);
            continue;
        }
        
        if(choice == "Purchase_Attack_Speed"){
            int []parameter = new int[2];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            parameter[1] = Convert.ToInt32(parameters_in_strings[1]);
            player[i].Purchase_Attack_Speed(parameter[0],parameter[1]);
            continue;
        }

        if(choice == "Purchase_Attack_Power"){
            int []parameter = new int[2];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            parameter[1] = Convert.ToInt32(parameters_in_strings[1]);
            player[i].Purchase_Attack_Power(parameter[0],parameter[1]);
            continue;
        }

        if(choice == "Purchase_Heal_Power"){
            int []parameter = new int[2];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            parameter[1] = Convert.ToInt32(parameters_in_strings[1]);
            player[i].Purchase_Heal_Power(parameter[0],parameter[1]);
            continue;
        }
        
        if(choice == "Purchase_Revives"){
            int []parameter = new int[2];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            parameter[1] = Convert.ToInt32(parameters_in_strings[1]);
            player[i].Purchase_Revives(parameter[0],parameter[1]);
            continue;
        }


        if(choice == "Purchase_Max_Criticle_Hit"){
            int []parameter = new int[2];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            parameter[1] = Convert.ToInt32(parameters_in_strings[1]);
            player[i].Purchase_Max_Criticle_Hit(parameter[0],parameter[1]);
            continue;
        }

        if(choice == "Gain_Gold"){
            int []parameter = new int[1];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            player[i].Gain_Gold(parameter[0]);
            continue;
        }

        if(choice == "Attack"){
            int []parameter = new int[1];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            if(player[i].Alive == false){
                Console.WriteLine("Player " + player[parameter[0]].UnitName + "is Already been killed by Someone" );
            }
            else{
                player[i].Attack(player[parameter[0]]);
                if(player[parameter[0]].Alive == false){
                    number_Of_players_Alive--;
                    Console.WriteLine("Player " + player[i].UnitName + " has been killed by Player " + player[parameter[0]].UnitName);
                    Console.WriteLine("Now There Are Only {0} number of players are remaining in Areana",number_Of_players_Alive)
                }
            }
            continue;
        }

        if(choice == "Heal"){
            int []parameter = new int[1];
            string [] parameters_in_strings = Console.ReadLine().Split(' ');
            parameter[0] = Convert.ToInt32(parameters_in_strings[0]);
            bool Initial_Condition = player[parameter[0]].Alive;
            player[i].Heal(player[parameter[0]]);
            if(player[parameter[0]].Alive == true && Initial_Condition == false){
                number_Of_players_Alive ++;
                Console.WriteLine("Player " + player[parameter[0]].UnitName + " has been revived by Player " + player[i].UnitName);
            }
            continue;
        }


    }
}