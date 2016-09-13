using System;

namespace Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"They say, a person's home is a reflection of their own character. It is a place to work, to relax, and to meet friends. My family lives in our own house. It is a small cottage in the suburbs of our town. It consists of the ground and the first floor and has five rooms in it. There is also a garage for our car, a small garden with beautiful flowers and fruit trees around the house.
If you come to our house, you enter our hall first. Here you may take off your coat and shoes. The floor is covered with a fitted carpet, so you will feel comfort¬able in our house. There is a kitchen, a bathroom, and a living room. We have dreamed for a long time about such a big kitchen. There is a big window and small curtains here, so the sunshine fills it, and makes it cozy. There is a gas cooker, a refrigerator, a cupboard, a sink unit and a big round table here. We gather, together every morning in our kitchen and have breakfast and wish each other a nice day.
When we have dinner with our guests, we usually have it in our living room is the biggest room in the house. The full-length curtains, elegant furniture and a big thick carpet on the floor make the room the best place to relax, watch TV and communicate with friends. The living-room suite, which consists of a cupboard, a bookcase, a sofa, and three armchairs, is arranged around three walls. A big colour TV-set and a video system near the window can transform the room into a cinema. We often watch here our favourite films.
My favourite place in our house is my bedroom, which is also my study. Every member of our family has furnished their rooms according to their own taste. As for me, I have chosen modern furniture, which doesn't take much place and can be easily transformed. The bedroom suite consists of a bed, a bedside table and a wardrobe. There is also a small desk with a lap top on it. The window overlooks our garden. I often sit by the window and watch a beautiful sunset.";
            try
            {
                WordsCounter wordsCounter = new WordsCounter(text);
                wordsCounter.Count();
                wordsCounter.ShowWordsFrequency(SortParameter.ByFrequency);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
