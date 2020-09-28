using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        string s = "\"hammad\"a";              //to take input.
        string word = "";          //to store characters
        bool checkFirstCharacter = true;  //to validate space
        string punctuator = "";      //to store punctuator
        int lineCounter = 1;         //to count line number
        bool isNumber = false;       //using in float validation
        int count = 0;               //using in float validation
        int storeKindex = 0;         //using in float validation
        int loopCounter = 0;         //using in single quote validation
        ArrayList wordsContainer = new ArrayList();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].ToString() != " " && s[i].ToString() != "\t" && s[i] != '\r' && s[i] != '\"' && s[i] != '\'' && s[i].ToString() != "(" && s[i].ToString() != ")" && s[i].ToString() != "{" && s[i].ToString() != "}" && s[i].ToString() != "[" && s[i].ToString() != "]" && s[i].ToString() != ":" && s[i].ToString() != ";" && s[i].ToString() != "," && s[i].ToString() != "." && s[i].ToString() != "+" && s[i].ToString() != "-" && s[i].ToString() != "*" && s[i].ToString() != "/" && s[i].ToString() != "%" && s[i].ToString() != "=" && s[i].ToString() != "&" && s[i].ToString() != "|" && s[i].ToString() != "!" && s[i].ToString() != ">" && s[i].ToString() != "<")
            {
                word = word + s[i].ToString(); //append characters
            }

            //SPACE!!
            else if (s[i].ToString() == " ")
            {
                if (s[0].ToString() == " " && checkFirstCharacter)
                { //if first character of a string is space then ignore it
                    checkFirstCharacter = false;                   //setting it false to check for first character space for one time only if it will be allowed to check for it each time it sees an space in string then it would be true always and wont add anything to arraylist
                }
                else                    //if space is in middle then add string before space in arraylist
                {
                    if (word != "")
                    {       //suppose there are  consecutive spaces in our inpuuted string then at first space it will add letters before space in arraylist then it will set word to smpty string now when it will encounter another consecutive space then it will add empty string in our arraylist as we set word to empty string after encountering first space so if I wont put this condition then it will add empty string inplace of each space inside our array list
                        wordsContainer.Add(word);
                        word = "";
                    }
                }
            }

            //TAB(\t)!!
            else if (s[i].ToString() == "\t")
            {
                if (s[0].ToString() == "\t" && checkFirstCharacter)
                { //if first character of a string is space then ignore it
                    checkFirstCharacter = false;                   //setting it false to check for first character space for one time only if it will be allowed to check for it each time it sees an space in string then it would be true always and wont add anything to arraylist
                }
                else                    //if space is in middle then add string before space in arraylist
                {
                    if (word != "")
                    {       //suppose there are  consecutive spaces in our inpuuted string then at first space it will add letters before space in arraylist then it will set word to smpty string now when it will encounter another consecutive space then it will add empty string in our arraylist as we set word to empty string after encountering first space so if I wont put this condition then it will add empty string inplace of each space inside our array list
                        wordsContainer.Add(word);
                        word = "";
                    }
                }
            }

            //LINE BREAK(\r)!!
            else if (s[i] == '\r')
            {
                if (word == "")
                {
                    i++;
                    lineCounter++; //incrementing line number as line has been changed
                }

                else
                {
                    wordsContainer.Add(word);
                    word = "";
                    i++; //now i will target \n and when our main loop will increment i then it will target the character written right after \n
                    lineCounter++; //incrementing line number as line has been changed
                }
            }

            //STRING!!
            else if (s[i] == '\"')
            {
                if (word != "")
                {
                    wordsContainer.Add(word);
                    word = "";
                    word = word + s[i].ToString();        //it will append first double quote to word variable
                }

                else
                {
                    word = word + s[i].ToString();            //it will append first double quote to word variable
                }

                for (i = i + 1; i < s.Length; i++)  //this loop will keep running unless no character is left in inputted string or break from inside
                {                          //i=i+1 cause double quotes are already added
                    if (s[i] != '\"' && s[i] == '\\' && s[i] != '\r')  //keep appending characters to word variable unless you encounter \r or another double quote
                    {
                        word = word + s[i].ToString();
                    }

                    else if (s[i] == '\\') //whenever you encounter \ go inside
                    {
                        if (i == s.Length - 1) //if \ is at last index
                        {
                            word = word + s[i].ToString(); //append \
                            wordsContainer.Add(word);
                            word = "";
                        }
                        else if (s[i + 1] == '\"') //go inside if after \ there is double quote 
                        {
                            word = word + s[i + 1].ToString();  //dont break string, instead append that double quote as a part of string
                            i++;  //incrementing so i starts pointing to double quote and in next iteration our i starts pointing to whatever there is after double quote,
                                  //if we wont increment i then in next iteration our code will go inside following else if block and will break the string
                        }
                        else //when after \ there is no double quote
                        {
                            word = word + s[i].ToString(); //append \
                        }
                    }

                    else if (s[i] == '\"')           //after encountering another double quote come inside
                    {
                        word = word + s[i].ToString();        //appending next double quote to word variable
                        wordsContainer.Add(word);
                        word = "";
                        break;
                    }

                    else                      //when line has been broken
                    {
                        i--;           //decrementing i so that when line has been changed then our index should point to the character written before current \r, so that after exiting from this loop when our main loop increments i then our index should point to current \r again and go into line break validation part
                        break;         //not writing \r validation  part here to minimize code repeatation, as we have already defined \r validation part above
                    }
                }
            }

            //CHARACTER!!
            else if (s[i] == '\'')
            {
                if (word != "")
                {
                    wordsContainer.Add(word);
                    word = "";
                    word = word + s[i].ToString();        //it will append first single quote to word variable
                }

                else
                {
                    word = word + s[i].ToString();           //it will append first single quote to word variable
                }

                if (i == s.Length - 1) //if single quote is at last index in inputted string, checking this condtion is necessary otherwise it will give error when single quote is at last index as in following condition we are using [i+1]
                {
                    wordsContainer.Add(word);
                    word = "";
                }

                else if (s[i + 1] == '\\') //if there is \ after single quote then add word variable to list once length of word variable reaches to 4
                {
                    loopCounter = i + 4;
                    for (i = i + 1; i < loopCounter; i++)
                    {
                        if (i == s.Length - 1) //if there are less than 3 characters after single quote. Omit this condition and give 'a as input and it will throw an error
                        {
                            if (s[i] == '\r') //incase if there is line break after single quote
                            {
                                break; //exiting from current loop, then after exiting i will decrement itself meaning that i will then point to character written right before current \r,
                                       //and then our main loop will increment i and then i will point to \r and go into line break validation part
                                       //not writing \r validation here to minimize code repeatation, as we have already defined \r validation part above
                            }
                            else
                            {
                                word = word + s[i].ToString();
                                i++; //incase if after single quote there are less than 3 characters then increment i so that after exiting from current loop, 
                                     //when we decrement i then it should point to last character and then when our main loop increments i then it should not run, 
                                     //if we wont increment i here then after exiting from current loop i will decrement itself and then when our main loop will increment i then it will target again to the last character,
                                     //so incrementing i is necessary when there are less than 3 characters after single quote (including \) and decrementing i is necessary after exiting current loop incase if there are 3 or more than 3 characters after single quote (including \),
                                     //omit this line and give input: '\a and output would be: '\a and on next line a again
                                break;
                            }
                        }
                        else  //if there after three characters after single then keep appending characters to word variable until loop terminates
                        {
                            if (s[i] == '\r') //incase if there is line break after single quote
                            {
                                break; //exiting from current loop, then after exiting i will decrement itself meaning that i will then point to character written right before current \r,
                                       //and then our main loop will increment i and then i will point to \r and go into line break validation part
                            }
                            else
                            {
                                word = word + s[i].ToString();
                            }
                        }
                    }
                    wordsContainer.Add(word);
                    word = "";
                    i = i - 1; //because after the completion of above loop i would be pointing to 4th character after single quote, suppose 'abcd is input now after completion of above loop i would point to d and then main loop will increment i again so we will lose character d
                }
                else                 //if there is no \ after single quote then add word variable to list when length of word variable reaches to 3
                {
                    loopCounter = i + 3;
                    for (i = i + 1; i < loopCounter; i++)
                    {
                        if (i == s.Length - 1) //if there are less than 2 characters after single quote, omit this condition and give 'a as input and it will throw an error
                        {

                            if (s[i] == '\r') //incase if there is line break after single quote
                            {
                                break; //exiting from current loop, then after exiting i will decrement itself meaning that i will then point to character written right before current \r,
                                       //and then our main loop will increment i and then i will point to \r and go into line break validation part
                            }
                            else
                            {
                                word = word + s[i].ToString();
                                i++; //incase if after single quote there are less than 2 characters then increment i so that after exiting from current loop,
                                     //when we decrement i then it should point to last character and then when our main loop increments i then it should not run, 
                                     //if we wont increment i here then after exiting from current loop i will decrement itself and then when our main loop will increment i then it will target again to the last character,
                                     //so incrementing i is necessary when there are less than 2 characters after single quote and decrementing i is necessary after exiting current loop incase if there are 2 or more than 2 characters after single quote,
                                     //omit this line and give input: 'a and output would be: 'a and on next line a again
                                break;
                            }
                        }
                        else
                        {
                            if (s[i] == '\r') //incase if there is line break after single quote
                            {
                                break; //exiting from current loop, then after exiting i will decrement itself meaning that i will then point to character written right before current \r,
                                       //and then our main loop will increment i and then i will point to \r and go into line break validation part
                            }
                            else
                            {
                                word = word + s[i].ToString();

                            }
                        }
                    }
                    wordsContainer.Add(word);
                    word = "";
                    i = i - 1; //because after the completion of above loop i would be pointing to 4th character after single quote, suppose 'abc is input now after completion of above loop i would point to c and then main loop will increment i again so we will lose character c
                }
            }

            //PUNCTUATORS!!

            else if (s[i].ToString() == "(" || s[i].ToString() == ")" || s[i].ToString() == "{" || s[i].ToString() == "}" || s[i].ToString() == "[" || s[i].ToString() == "]" || s[i].ToString() == ":" || s[i].ToString() == ";" || s[i].ToString() == ",")
            {
                punctuator = s[i].ToString();
                if (word == "") //if there is any word breaker before current punctuator
                {
                    wordsContainer.Add(punctuator);
                }
                else if (word != "")
                {
                    wordsContainer.Add(word);
                    wordsContainer.Add(punctuator);
                    word = "";
                }
            }


            // "." punctuator/ float

            else if (s[i].ToString() == ".")
            {
                count = 0;  //making it 0 so that if  word is empty then still we can come inside above ifcount==word.Length) and check whether next character after "." is a number or not. If it is a number then execute if(char.IsDigit(s,i+1)) block of code written inside ifcount==word.Length) otherwise execute else part in which we are only adding "." to array list
                for (int j = 0; j < word.Length; j++)  //checking whether word contains of all numbers or no
                {
                    isNumber = char.IsDigit(word, j);
                    if (isNumber)
                    {
                        count++; //everytime there is a number inside word then increment count by 1
                    }
                }

                if (count == word.Length)   //if before "." there are all numbers
                {                        //if count and length of word variable is equal means that word contains all numbers

                    if (i == s.Length - 1) //if "." is the last character of our inputted string, not checking this would give error 
                    {
                        if (word == "")
                        {
                            wordsContainer.Add(".");
                        }

                        else if (word != "")
                        {
                            wordsContainer.Add(word);
                            wordsContainer.Add(".");
                            word = "";
                        }
                    }
                    else if (char.IsDigit(s, i + 1)) //if next character after dot is number then welcome inside
                    {
                        word = word + s[i].ToString(); //appending dot with word
                        for (int k = i + 1; k < s.Length; k++) //here we will keep appending characters after dot unless we encounter a word breaker
                        {
                            if (s[k].ToString() != " " && s[k].ToString() != "(" && s[k].ToString() != ")" && s[k].ToString() != "{" && s[k].ToString() != "}" && s[k].ToString() != "[" && s[k].ToString() != "]" && s[k].ToString() != ":" && s[k].ToString() != ";" && s[k].ToString() != "," && s[k].ToString() != "." && s[k].ToString() != "+" && s[k].ToString() != "-" && s[k].ToString() != "*" && s[k].ToString() != "/" && s[k].ToString() != "%" && s[k].ToString() != "=" && s[k].ToString() != "&" && s[k].ToString() != "|" && s[k].ToString() != "!" && s[k].ToString() != ">" && s[k].ToString() != "<")
                            {
                                word = word + s[k].ToString();
                            }
                            else //when you encounter word breaker
                            {    //if last character of our inputted string won't be a word breaker then this else part would not run and as a result our word variable would be filled with some value and then in "printing last value part" of our program it would be appended again in word variable which we don't want
                                wordsContainer.Add(word);
                                word = "";
                                i = k - 1; //setting i to k-1 so after that after this iteration outer/main loop should point to that word breaker
                                break;
                            }
                            storeKindex = k; //to set i to k to pass in the following condition
                        }
                        if (word != "") //this will run when above else part won't run means it will run when after dot there is no word breaker till the end of our inputted string, remove this condition and give 9.7a as input and you will see that in the end our word variable would contain 9.7a7a
                        {            //whole point of this condtion is to make our word variable empty if it is full
                            wordsContainer.Add(word);
                            word = "";
                            i = storeKindex; //setting i to last index of our inputted string so our main loop doesn't run again as we will only come in this condtion if we encounter last character of our inputted string after "." instead of word breaker
                        }
                    }

                    else //when before "." there are all numbers but after "." next character is not a number
                    {
                        if (word != "") //exclude this condtion and give input 9.a and wc error
                        {
                            wordsContainer.Add(word);
                            word = "";
                            wordsContainer.Add(".");
                        }
                        else         //when before "." there is word breaker/ word is empty
                        {
                            wordsContainer.Add(".");
                        }
                    }
                }

                else //if before "." there is atleast one letter
                {

                    wordsContainer.Add(word);
                    word = ""; //remove this line and give c.9 input and output would be: c and then c.9				
                    if (i == s.Length - 1) //if "." is the last character of our inputted string, not checking this would give error 
                    {                     //if we will come inside this if means that "." is the last character
                        wordsContainer.Add(".");
                    }

                    else if (char.IsDigit(s, i + 1)) //if next character after dot is number then welcome inside
                    {
                        word = word + s[i].ToString(); //appending dot with word
                        for (int k = i + 1; k < s.Length; k++) //here we will keep appending characters after dot unless we encounter a word breaker
                        {
                            if (s[k].ToString() != " " && s[k].ToString() != "(" && s[k].ToString() != ")" && s[k].ToString() != "{" && s[k].ToString() != "}" && s[k].ToString() != "[" && s[k].ToString() != "]" && s[k].ToString() != ":" && s[k].ToString() != ";" && s[k].ToString() != "," && s[k].ToString() != "." && s[k].ToString() != "+" && s[k].ToString() != "-" && s[k].ToString() != "*" && s[k].ToString() != "/" && s[k].ToString() != "%" && s[k].ToString() != "=" && s[k].ToString() != "&" && s[k].ToString() != "|" && s[k].ToString() != "!" && s[k].ToString() != ">" && s[k].ToString() != "<")
                            {
                                word = word + s[k].ToString();
                            }
                            else //when you encounter word breaker
                            {    //if last character of our inputted string won't be a word breaker then this else part would not run and as a result our word variable would be filled with some value and then in "printing last value part" of our program it would be appended again in word variable which we don't want
                                wordsContainer.Add(word);
                                word = "";
                                i = k - 1; //setting i to k-1 so after that after this iteration outer/main loop should point to that word breaker
                                break;
                            }
                            storeKindex = k; //to set i to k to pass in the following condition
                        }
                        if (word != "") //this will run when above else part won't run means it will run when after dot there is no word breaker till the end of our inputted string, remove this condition and give 9.7a as input and you will see that in the end our word variable would contain 9.7a7a
                        {            //whole point of this condtion is to make our word variable empty if it is full
                            wordsContainer.Add(word);
                            word = "";
                            i = storeKindex; //setting i to last index of our inputted string so our main loop doesn't run again as we will only come in this condtion if we encounter last character of our inputted string after "." instead of word breaker
                        }
                    }
                    else  //if next character after "." is not a number
                    {
                        if (word != "") //dont include this if and give a.b input and wc error
                        {
                            wordsContainer.Add(word);
                            word = "";
                            wordsContainer.Add(".");
                        }
                        else         //when before "." there is word breaker/ word is empty
                        {
                            wordsContainer.Add(".");
                        }
                    }

                }

            }


            //OPERATORS!!


            //+
            else if (s[i].ToString() == "+")
            {
                if (i == s.Length - 1) //if + is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("+");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("+");
                        word = "";
                    }
                }

                //++
                else if (s[i + 1].ToString() == "+") //when there are 2 consecutive + (means increment)
                {
                    if (word == "")
                    {
                        wordsContainer.Add("++");
                        i++; //incrementing i so that if there are three or more consecutive + then after this iteration i should point to third + not second
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("++");
                        i++;
                        word = "";
                    }

                }

                //+=
                else if (s[i + 1].ToString() == "=") //when there is = after +
                {
                    if (word == "")
                    {
                        wordsContainer.Add("+=");
                        i++; //incrementing i so that if there is = after + then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("+=");
                        i++;
                        word = "";
                    }
                }

                //only + (in middle or start)
                else //means there is neither + nor = after +
                {
                    if (word == "") //if there are consecutive "+" or there is space before + or any other word breaker
                    {
                        wordsContainer.Add("+");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("+");
                        word = "";
                    }
                }
            }

            //-
            else if (s[i].ToString() == "-")
            {
                if (i == s.Length - 1) //if - is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("-");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("-");
                        word = "";
                    }
                }

                //--
                else if (s[i + 1].ToString() == "-") //when there are 2 consecutive - (means increment)
                {
                    if (word == "")
                    {
                        wordsContainer.Add("--");
                        i++; //incrementing i so that if there are three or more consecutive - then after this iteration i should point to third - not second
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("--");
                        i++;
                        word = "";
                    }

                }

                //-=
                else if (s[i + 1].ToString() == "=") //when there is = after -
                {
                    if (word == "")
                    {
                        wordsContainer.Add("-=");
                        i++; //incrementing i so that if there is = after - then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("-=");
                        i++;
                        word = "";
                    }
                }

                //only - (in middle or start)
                else //means there is neither - nor = after -
                {
                    if (word == "") //if there are consecutive "-" or there is space before - or any other word breaker
                    {
                        wordsContainer.Add("-");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("-");
                        word = "";
                    }
                }
            }

            //*
            else if (s[i].ToString() == "*")
            {
                if (i == s.Length - 1) //if * is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("*");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("*");
                        word = "";
                    }
                }

                //*=
                else if (s[i + 1].ToString() == "=") //when there is = after *
                {
                    if (word == "")
                    {
                        wordsContainer.Add("*=");
                        i++; //incrementing i so that if there is = after * then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("*=");
                        i++;
                        word = "";
                    }
                }

                //only * (in middle or start)
                else //means there is no = after *
                {
                    if (word == "") //if there are consecutive "*" or there is space before * or any other word breaker
                    {
                        wordsContainer.Add("*");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("*");
                        word = "";
                    }
                }
            }

            // /
            else if (s[i].ToString() == "/")
            {
                if (i == s.Length - 1) //if / is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("/");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("/");
                        word = "";
                    }
                }

                //SINGLE LINE COMMENT!!
                else if (s[i + 1].ToString() == "/")
                {
                    if (word != "")
                    {
                        wordsContainer.Add(word);
                        word = "";
                        for (i = i; i < s.Length; i++) //keep adding characters in word variable from first forward slash unless you encounter \r
                        {
                            if (s[i] != '\r')
                            {
                                word = word + s[i].ToString();
                            }
                        }
                    }
                    else
                    {
                        for (i = i; i < s.Length; i++)
                        {
                            if (s[i] != '\r')
                            {
                                word = word + s[i].ToString();
                            }
                        }
                    }
                }

                //MULTI LINE COMMENT!!
                else if (s[i + 1].ToString() == "*")
                {
                    if (word != "")
                    {
                        wordsContainer.Add(word);
                        word = "";
                        word = word + "/*";
                        for (i = i + 2; i < s.Length; i++) //keep adding characters in word variable from first forward slash unless you encounter *\
                        {                         //i=i+2 so that loop start appending characters from character after /*
                            if (s[i] != '*') //keep adding characters in word variable unless you encounter *
                            {
                                word = word + s[i].ToString();
                                if (s[i] == '\r') //if current character is \r then come inside
                                {
                                    if (i == s.Length - 1) //if \r is last character then go to next iteration
                                    {
                                        continue;
                                    }

                                    else if (s[i + 1] == '\n') //else if after \r there is \n then it means line break hence increment line counter and keep going
                                    {
                                        lineCounter++;
                                    }
                                }
                            }
                            else //come inside when you encounter *
                            {
                                if (s[i + 1].ToString() == "/") //checking if next character after * is / or not, it it is then go inside 
                                {
                                    word = word + "*/";
                                    wordsContainer.Add(word);
                                    word = "";
                                    i++; //setting pointer to / after * so that our main loop points to character after / in next iteration
                                    break;
                                }
                                else //if next character after * is not / then simply append * to word variable
                                {
                                    word = word + s[i].ToString();
                                }

                            }
                        }
                    }

                    else
                    {
                        word = word + "/*";
                        for (i = i + 2; i < s.Length; i++) //keep adding characters in word variable from first forward slash unless you encounter *\
                        {                         //i=i+2 so that loop start appending characters from character after /*
                            if (s[i] != '*') //keep adding characters in word variable unless you encounter *
                            {
                                word = word + s[i].ToString();
                                if (s[i] == '\r') //if current character is \r then come inside
                                {
                                    if (i == s.Length - 1) //if \r is last character then go to next iteration
                                    {
                                        continue;
                                    }

                                    else if (s[i + 1] == '\n') //else if after \r there is \n then it means line break hence increment line counter and keep going
                                    {
                                        lineCounter++;
                                    }
                                }
                            }
                            else //come inside when you encounter *
                            {
                                if (s[i + 1].ToString() == "/") //checking if next character after * is / or not, it it is then go inside 
                                {
                                    word = word + "*/";
                                    wordsContainer.Add(word);
                                    word = "";
                                    i++; //setting pointer to / after * so that our main loop points to character after / in next iteration
                                    break;
                                }
                                else //if next character after * is not / then simply append * to word variable
                                {
                                    word = word + s[i].ToString();
                                }

                            }
                        }
                    }
                }

                // /=
                else if (s[i + 1].ToString() == "=") //when there is = after /
                {
                    if (word == "")
                    {
                        wordsContainer.Add("/=");
                        i++; //incrementing i so that if there is = after / then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("/=");
                        i++;
                        word = "";
                    }
                }

                //only / (in middle or start)
                else //means there is no = after /
                {
                    if (word == "") //if there are consecutive "/" or there is space before / or any other word breaker
                    {
                        wordsContainer.Add("/");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("/");
                        word = "";
                    }
                }
            }

            //%
            else if (s[i].ToString() == "%")
            {
                if (word == "") //if there are consecutive "%" or there is space before "%" or any other word breaker
                {
                    wordsContainer.Add("%");
                }
                else if (word != "")
                {
                    wordsContainer.Add(word);
                    wordsContainer.Add("%");
                    word = "";
                }
            }

            // =
            else if (s[i].ToString() == "=")
            {
                if (i == s.Length - 1) //if = is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("=");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("=");
                        word = "";
                    }
                }

                //==
                else if (s[i + 1].ToString() == "=") //when there is = after = (two consecutive =)
                {
                    if (word == "")
                    {
                        wordsContainer.Add("==");
                        i++; //incrementing i so that if there is = after = then after this iteration i should point to whatever there is after second =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("==");
                        i++;
                        word = "";
                    }
                }

                //only = (in middle or start)
                else //means there is no = after =
                {
                    if (word == "") //if there are consecutive "=" or there is space before = or any other word breaker
                    {
                        wordsContainer.Add("=");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("=");
                        word = "";
                    }
                }
            }


            //&&
            else if (s[i].ToString() == "&")
            {
                if (i == s.Length - 1 || s[i + 1].ToString() != "&") //if & is at last index means there can't be two consecutive & so single & is supposed to be appended with word, similarly if there is not another & follwing & then it means that there are not two consecutive & and single & should be appended to word
                {
                    word = word + s[i].ToString();
                }
                else
                {
                    if (word == "")
                    {
                        wordsContainer.Add("&&");
                        i++;
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("&&");
                        i++;
                        word = "";
                    }
                }
            }

            //||
            else if (s[i].ToString() == "|")
            {
                if (i == s.Length - 1 || s[i + 1].ToString() != "|") //if | is at last index means there can't be two consecutive | so single | is supposed to be appended with word, similarly if there is not another | follwing | then it means that there are not two consecutive | and single | should be appended to word
                {
                    word = word + s[i].ToString();
                }
                else
                {
                    if (word == "")
                    {
                        wordsContainer.Add("||");
                        i++;
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("||");
                        i++;
                        word = "";
                    }
                }
            }

            //!
            else if (s[i].ToString() == "!")
            {
                if (i == s.Length - 1) //if ! is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("!");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("!");
                        word = "";
                    }
                }

                // !=
                else if (s[i + 1].ToString() == "=") //when there is = after !
                {
                    if (word == "")
                    {
                        wordsContainer.Add("!=");
                        i++; //incrementing i so that if there is = after ! then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("!=");
                        i++;
                        word = "";
                    }
                }

                //only ! (in middle or start)
                else //means there is no = after !
                {
                    if (word == "") //if there are consecutive "!" or there is space before ! or any other word breaker
                    {
                        wordsContainer.Add("!");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("!");
                        word = "";
                    }
                }
            }

            //>
            else if (s[i].ToString() == ">")
            {
                if (i == s.Length - 1) //if > is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add(">");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add(">");
                        word = "";
                    }
                }

                // >=
                else if (s[i + 1].ToString() == "=") //when there is = after >
                {
                    if (word == "")
                    {
                        wordsContainer.Add(">=");
                        i++; //incrementing i so that if there is = after > then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add(">=");
                        i++;
                        word = "";
                    }
                }

                //only > (in middle or start)
                else //means there is no = after >
                {
                    if (word == "") //if there are consecutive ">" or there is space before > or any other word breaker
                    {
                        wordsContainer.Add(">");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add(">");
                        word = "";
                    }
                }
            }

            //<
            else if (s[i].ToString() == "<")
            {
                if (i == s.Length - 1) //if < is the last character of our inputted string, not checking this would give exception error 
                {
                    if (word == "")
                    {
                        wordsContainer.Add("<");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("<");
                        word = "";
                    }
                }

                // <=
                else if (s[i + 1].ToString() == "=") //when there is = after <
                {
                    if (word == "")
                    {
                        wordsContainer.Add("<=");
                        i++; //incrementing i so that if there is = after < then after this iteration i should point to whatever there is after =
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("<=");
                        i++;
                        word = "";
                    }
                }

                //only < (in middle or start)
                else //means there is no = after <
                {
                    if (word == "") //if there are consecutive "<" or there is space before < or any other word breaker
                    {
                        wordsContainer.Add("<");
                    }

                    else if (word != "")
                    {
                        wordsContainer.Add(word);
                        wordsContainer.Add("<");
                        word = "";
                    }
                }
            }
        }

        //Printing last letter/letters of our inputted string, if we wont then it will not add it into array list. e.g: "int b" now if we wont add follwing three lines then it will only add int in arraylist
        if (word != "")  //if last character of our inputted string is space then our word would be set to empty string, so if I wont specify this condition then empty string would be added at the last of our arraylist
        {
            wordsContainer.Add(word);
        }
        for (int i = 0; i < wordsContainer.Count; i++) //Priting broken words
        {
            Console.WriteLine(wordsContainer[i]);
        }
    }
}
