using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turn_base_battle_game{

    class Unit{

        private int Current_hp;
        private int Max_hp;
        private int Attack_Power;
        private int Heal_Power;
        public string UnitName;
        private Random random;
        private int Criticle_Chance;
        public bool Alive;
        private int Revive_Left;
        private int Criticle_Hit;
        private int Attack_Speed;
        private int Base_Attack_Speed;
        private bool Has_Armour = false;
        private int Gold_Remaining = 0;
        private int Armour_Reduction;
        private int Max_Criticle_Hit = 61;

        public Unit(int Max_hp, int Attack_Power, int Heal_Power,string UnitName, int Criticle_Chance , int Revive_Left, int Attack_Speed , int Base_Attack_Speed){
            this.Max_hp = Max_hp;
            this.Current_hp = Max_hp;
            this.Attack_Power = Attack_Power;
            this.Heal_Power = Heal_Power;
            this.UnitName = UnitName;
            this.random = new Random();
            this.Criticle_Hit = random.Next(40,Max_Criticle_Hit);
            this.Criticle_Chance = Criticle_Chance;
            this.Revive_Left = Revive_Left;
            this.Attack_Speed = Attack_Speed;
            this.Base_Attack_Speed = Base_Attack_Speed;
            Alive = true;
        }
        public void Update_Attack_Power(int x){
            Attack_Power += x;
            Attack_Power=Math.Min(Attack_Power,(int)(0.65*Max_hp));
            if(Attack_Power == (int)0.65*Max_hp){
                Console.WriteLine("You have Reached Max Attack Power");
            }
            return;
        }
        
        public void Update_Heal_Power(int x){
            Heal_Power += x;
            Heal_Power=Math.Min(Heal_Power,(int)(0.35*Max_hp));
            if(Criticle_Chance == (int)0.35*Max_hp){
                Console.WriteLine("You Have Reached Max Heal Power");
            }
            return;
        }

        public void Update_Max_hp(int x){
            Max_hp += x;
            return;
        }

        public void Update_Criticle_Chance(int x){
            Criticle_Chance += x;
            Criticle_Chance=Math.Min(Criticle_Chance,75);
            if(Criticle_Chance == 75){
                Console.WriteLine("You Have Reached Max Criticle Chace");
            }
            return;
        }
        
        public void Update_Attack_Speed(int x){
            Attack_Speed += x;
            Attack_Speed = Math.Min(Attack_Speed,Base_Attack_Speed);
            if(Attack_Speed == Base_Attack_Speed){
                Console.WriteLine("You Have Reached Max Attack Speed");
            }
            return;
        }


        public void Update_Revives(int x){
            Revive_Left += x;
            Revive_Left = Math.Min(Revive_Left,(int) 3);
            if(Revive_Left == 3){
                Console.WriteLine("You Have Max Numbers of Revives Now!!");
            }
            return;
        }

        public void Update_Max_Criticle_Hit(int x){
            Max_Criticle_Hit += x;
            return;
        }
        
        public void Update_Gold_Remaining(int x){
            Gold_Remaining += x;
            return;
        }
        
        public void Purchase_Armour(int x,int y){
            if(Gold_Remaining >= x){
                Gold_Remaining -= x;
                Armour_Reduction = y;
                Has_Armour = true;
                Console.WriteLine("You have purchased {0} armour for {1} gold", y, x);
            }
            else{
                Console.WriteLine("You don't have enough gold");
            }
            return;
        }

        public void Purchase_Attack_Speed(int x,int y){
            if(Gold_Remaining >= x){
                Gold_Remaining -= x;
                Update_Attack_Speed(y);
                Console.WriteLine("You have purchased {0} Attack Speed for {1} gold", y, x);
            }
            else{
                Console.WriteLine("You don't have enough gold");
            }
            return;
        }

        public void Purchase_Attack_Power(int x,int y){
            if(Gold_Remaining >= x){
                Gold_Remaining -= x;
                Update_Attack_Power(y);
                Console.WriteLine("You have purchased {0} Attack Power for {1} gold", y, x);
            }
            else{
                Console.WriteLine("You don't have enough gold");
            }
            return;
        }

        public void Purchase_Heal_Power(int x,int y){
            if(Gold_Remaining >= x){
                Gold_Remaining -= x;
                Update_Heal_Power(y);
                Console.WriteLine("You have purchased {0} Heal Power for {1} gold", y, x);
            }
            else{
                Console.WriteLine("You don't have enough gold");
            }
            return;
        }

       public void Purchase_Revives(int x,int y){
            if(Gold_Remaining >= x){
                Gold_Remaining -= x;
                Update_Revives(y);
                Console.WriteLine("You have purchased {0} Revive for {1} gold", y, x);
            }
            else{
                Console.WriteLine("You don't have enough gold");
            }
            return;
        }
        
        public void Purchase_Max_Criticle_Hit(int x,int y){
            if(Gold_Remaining >= x){
                Gold_Remaining -= x;
                Update_Max_Criticle_Hit(y);
                Console.WriteLine("You have purchased {0} Revive for {1} gold", y, x);
            }
            else{
                Console.WriteLine("You don't have enough gold");
            }
            return;
        }

        public void Gain_Gold(int x){
            Gold_Remaining += x;
            Gold_Remaining = Math.Min(Gold_Remaining, 99999);
            if(Gold_Remaining == 99999){
                Console.WriteLine("You have Reached Max Gold");
            }
            return;
        }

        public void Attack(Unit Unit_to_Attack){
            int Check_criticle_chance = random.Next(1,101);
            if(Check_criticle_chance <= Criticle_Chance){
                double Attack_damadge = (1+Criticle_Hit/100)*Attack_Power;
                Unit_to_Attack.Take_damadge((int)Attack_damadge);
                Console.WriteLine("Unit has done {0} Damadge to the {1} unit",(int)Attack_damadge,Unit_to_Attack.UnitName);
            }
            else{
                double Attack_damadge = (1)*Attack_Power;
                Unit_to_Attack.Take_damadge((int)Attack_damadge);
                Console.WriteLine("Unit has done {0} Damadge to the {1} unit",(int)Attack_damadge,Unit_to_Attack.UnitName);
            }
            return;
        }

        public void Take_damadge(int Incoming_damadge){
            Current_hp -= Incoming_damadge;
            if(Current_hp <= 0){
                Current_hp = 0;
            }
            if(Current_hp == 0){
                Console.WriteLine("Unit " + UnitName + " Has fallen");
            }
            return;
        }

        public void Heal(Unit Unit_to_Heal){
            if(Unit_to_Heal.Alive == false){
                Revive_First(Unit_to_Heal);
                if(Unit_to_Heal.Alive == false) return;
                Console.WriteLine("Unit {0} has been revived by {1}", Unit_to_Heal.UnitName, UnitName);
                int Check_criticle_chance1 = random.Next(1,101);
                if(Check_criticle_chance1 <= Criticle_Chance){
                    double Total_Heal1 = (1+Criticle_Hit/100)*Heal_Power;
                    Unit_to_Heal.Take_Healing((int)Total_Heal1);
                    Console.WriteLine("Unit has done {0} Healing to the {1} unit", (int)Total_Heal1, Unit_to_Heal.UnitName);
                    Unit_to_Heal.Current_hp = (int)(0.4*Unit_to_Heal.Max_hp) + (int)Total_Heal1;
                    return ;
                }
                else{
                    double Total_Heal1 = (1)*Heal_Power;
                    Unit_to_Heal.Take_Healing((int)Total_Heal1);
                    Console.WriteLine("Unit has done {0} Healing to the {1} unit",(int)Total_Heal1,Unit_to_Heal.UnitName);
                    Unit_to_Heal.Current_hp = (int)(0.4*Unit_to_Heal.Max_hp) + (int)Total_Heal1;
                    return ;
                }
            }
            int Check_criticle_chance = random.Next(1,101);
            if(Check_criticle_chance <= Criticle_Chance){
                double Total_Heal = (1+Criticle_Hit/100)*Heal_Power;
                Unit_to_Heal.Take_Healing((int)Total_Heal);
                Console.WriteLine("Unit has done {0} Healing to the {1} unit", (int)Total_Heal, Unit_to_Heal.UnitName);
            }
            else{
                double Total_Heal = (1)*Heal_Power;
                Unit_to_Heal.Take_Healing((int)Total_Heal);
                Console.WriteLine("Unit has done {0} Healing to the {1} unit",(int)Total_Heal,Unit_to_Heal.UnitName);
            }
            return;
        }

        public void Take_Healing(int Incoming_Healing){
            Current_hp += Incoming_Healing;
            return;
        }

        private void Revive_First(Unit Unit_to_Revive){
            if(Revive_Left == 0){
                Console.WriteLine("You Don't have any Revive left");
                return;
            }
            Unit_to_Revive.Alive = true;
            Revive_Left--;
            if(Revive_Left == 0){
                Console.WriteLine("Carefull!! You don't have any Revive left");
            }
            return;
        }
    }
}