using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TMP_Text questText;

    private string quest1 = "???";
    private string quest2 = "???";
    private string quest3 = "???";
    private string quest4 = "???";
    private string quest5 = "???";

    //Quest 1
    private int applesCollected = 0;

    //Quest 2
    private int lettersDelivered = 0;

    //Quest 3
    private bool hasRedPotion = false;
    private bool hasBluePotion = false;
    private bool hasGreenPotion = false;

    //Quest 4
    private bool sign1Read = false;
    private bool sign2Read = false;
    private bool sign3Read = false;
    private bool sign4Read = false;
    private bool sign5Read = false;

    //Quest 5
    private int carrotsCollected = 0;

    private void Start()
    {
        RefreshQuestNames();
    }

    public void UpdateQuest(GameObject npc)
    {
        //Quest 1
        if(npc.name == "Old Lady")
        {
            if (applesCollected == 3) quest1 = "Quest Completed!";
            else quest1 = $"Collect 3 Apples ({applesCollected}/3)";
        }
        //Quest 2
        if(npc.name == "Green Hair")
        {
            if (lettersDelivered == 0) quest2 = "Deliver the letter to the Blonde Girl with a half shaved head";
            else if (lettersDelivered == 2) quest2 = "Deliver the final letter to the Blonde Girl";
        }
        if(npc.name == "Blonde Hair")
        {
            if (lettersDelivered == 3) quest2 = "Quest Completed!";
            else if (lettersDelivered == 1) quest2 = "Deliver the blondes letter to the Green Haired Girl";
        }
        //Quest 3
        if(npc.name == "Witch")
        {
            if (!hasRedPotion) quest3 = "Find the Red \"Energy Drink\" and give it to the Witch";
            else if (hasRedPotion && !hasBluePotion) quest3 = "Find the Blue \"Energy Drink\" and give it to the Witch";
            else if (hasRedPotion && hasBluePotion && !hasGreenPotion) quest3 = "Find the Green Potion and give it to the Witch";
            else quest3 = "Quest Completed!";
        }
        //Quest 4
        if(npc.name == "Old Man")
        {
            int signsRead = 0;

            if (sign1Read) signsRead++;
            if (sign2Read) signsRead++;
            if (sign3Read) signsRead++;
            if (sign4Read) signsRead++;
            if (sign5Read) signsRead++;

            if (signsRead == 5) quest4 = "Quest Completed!";
            else quest4 = $"Read all the signs in the park ({signsRead}/5)";
        }
        //Quest 5
        if(npc.name == "Uma")
        {
            if (carrotsCollected == 3) quest5 = "Quest Completed!";
            else quest5 = $"Collect 3 Carrots ({carrotsCollected}/3)";
        }
        RefreshQuestNames();
    }

    public void UpdatePickups(GameObject pickup)
    {
        //Quest 1
        if (pickup.name == "Apple")
        {
            applesCollected++;
            if (quest1 != "???") quest1 = $"Collect 3 Apples ({applesCollected}/3)";
            if (applesCollected == 3) quest1 = "Return the Apples to the Old Lady";
        }
        //Quest 3
        if (pickup.name == "Red Potion") hasRedPotion = true;
        if (pickup.name == "Blue Potion") hasBluePotion = true;
        if (pickup.name == "Green Potion") hasGreenPotion = true;
        //Quest 5
        if (pickup.name == "Carrot")
        {
            carrotsCollected++;
            if (quest5 != "???") quest5 = $"Collect 3 Carrots ({carrotsCollected}/3)";
            if (carrotsCollected == 3) quest5 = "Bring the carrots to the Strange Horse Girl";
        }
        RefreshQuestNames();
    }

    public void UpdateReadSigns(GameObject sign)
    {
        if (sign.name == "Sign1") sign1Read = true;
        if (sign.name == "Sign2") sign2Read = true;
        if (sign.name == "Sign3") sign3Read = true;
        if (sign.name == "Sign4") sign4Read = true;
        if (sign.name == "Sign5") sign5Read = true;

        int signsRead = 0;

        if (sign1Read) signsRead++;
        if (sign2Read) signsRead++;
        if (sign3Read) signsRead++;
        if (sign4Read) signsRead++;
        if (sign5Read) signsRead++;

        if (signsRead == 5 && quest4 != "???") quest4 = "Return to the Old Man and give him your knowledge";
        else if (quest4 != "???") quest4 = $"Read all the signs in the park ({signsRead}/5)";

        RefreshQuestNames();
    }

    public string[] UpdateSentence(GameObject npc)
    {
        if(npc.name == "Old Lady")
        {
            if (quest1 == "???") return new string[] { "Hello young NON GENDER SPECIFIC child!", "You don't seem to be doing anything important with your life right now.", "Would you mind grabbing me 3 apples?" };
            else if (quest1 == "Return the Apples to the Old Lady") return new string[] { "Oh thank you NON GENDER SPECIFIC child!", "Because of your valient effort I will not starve.", "Huh? You want payment? Is helping an old lady not enough for you? Kids these days...." };
            else if (quest1 == "Quest Completed!") return new string[] { "These apples are delicious!", "I really can't thank you enough for getting me these.", "Seriously, I have no cash, scram." };
            else return new string[] { "Um..........", "You haven't gotten me all my apples sweetie.........", "You do know how to count, right?" };
        }
        if(npc.name == "Green Hair")
        {
            if (quest2 == "???") return new string[] { "Psst! Hey Kid!", "Listen, I'm too shy to do it in person, can you deliver this letter to the cute blonde girl up the road?", "Thanks kid, remember, she has half her head shaved if you forget who to look for." };
            else if (quest2 == "Deliver the letter to the Blonde Girl with a half shaved head") return new string[] { "Don't worry about what's in the letter", "I just think she's really cool, maybe her and I can be platonic straight roommates?", "It's not your business, just deliver the letter to her, please." };
            else if (quest2 == "Deliver the blondes letter to the Green Haired Girl")
            {
                lettersDelivered++;
                return new string[] { "Wait a minute..... She had one for me too?", "Wait right here!!! (You notice her frantically writing another \"platonic\" note)", "Bring this to her please!!!!" };
            }
            else if (quest2 == "Deliver the final letter to the Blonde Girl") return new string[] { "Don't dilly dally!", "My quest for lov- um platonic friendship is at stake", "What? I'm not doing it myself, I'm too shy." };
            else return new string[] { "Thanks for helping by the way, I put my phone number in the letter so you don't need to help anymore.", "My new girlfriend and I are going to move in soon. What? I thought it was obvious I liked her.", "Sorry, I don't have any spare cash as thanks." };
        }
        if (npc.name == "Blonde Hair")
        {
            if (quest2 == "???") return new string[] { "Do I know you? Sorry, I'm having a rough day.", "Yeah, I do think it's a nice trail. It's just I wish I had someone to hang with.", "Someone my own age, scram kid." };
            else if (quest2 == "Deliver the letter to the Blonde Girl with a half shaved head")
            {
                lettersDelivered++;
                return new string[] { "Huh? A letter addressed to me?", "Wait, I know this handwriting. I had no idea she felt-", "I should've done this sooner, but can you bring my letter to her?" };
            }
            else if (quest2 == "Deliver the blondes letter to the Green Haired Girl") return new string[] { "Come on kid! We don't have time, bring my letter to her, please.", "If I wasn't so embarrassed about not telling her I'd do it myself.", "I'm counting on you." };
            else if (quest2 == "Deliver the final letter to the Blonde Girl")
            {
                lettersDelivered++;
                return new string[] { "(You notice a sea of red go over the girls face)", "She didn't let you read this, right?", "Get outta here kid, I've got a cute girl to call." };
            }
            else return new string[] { "Reward? Dude I'm a broke college student I got no cash.", "Thanks for delivering my letter though.", "But seriously, scram." };
        }
        if (npc.name == "Witch")
        {
            if (quest3 == "???") return new string[] { "Hello Child.......", "I seem to have misplaced my Potio- I mean my Energy Drinks", "Can you find my Red Energy Drink dear?" };
            else if (quest3 == "Find the Red \"Energy Drink\" and give it to the Witch" && !hasRedPotion) return new string[] { "Hurry up and find that Energy Drink of mine child", "For if you do not I will unleash a curse apon your bloodline!", "Just kidding! I'll just be minorly upset." };
            else if (quest3 == "Find the Red \"Energy Drink\" and give it to the Witch" && hasRedPotion) return new string[] { "Ah my Potio- Enery Drink!", "I just remembered I misplaced my Blue one as well.", "Maybe if you find it I'll have a reward for you?" };
            else if (quest3 == "Find the Blue \"Energy Drink\" and give it to the Witch" && !hasBluePotion) return new string[] { "What? Don't believe me?", "I'm just a poor old lady looking for her Energy Drinks.", "Trust that this quest is worth it." };
            else if (quest3 == "Find the Blue \"Energy Drink\" and give it to the Witch" && hasBluePotion) return new string[] { "Thank you so much Child!", "I just have 1 more potion if you grab it, it's green.", "Err.... Did I say Potion?" };
            else if (quest3 == "Find the Green Potion and give it to the Witch" && !hasGreenPotion) return new string[] { "Hurry up dear and grab my last Potion!", "Or else you'll find out why I want them in the first place.....", "Chop Chop!" };
            else if (quest3 == "Find the Green Potion and give it to the Witch" && hasGreenPotion) return new string[] { "At last, my last potion!", "You best run along while I do my experiments....", "What? Reward? Never trust a Witch!" };
            else return new string[] { "Seriously kid, get outta here, I'm not interested in using you as a test subject", "It doesn't pay to be a witch, so I got no reward for you.", "Git!" };
        }
        if (npc.name == "Old Man")
        {
            if (quest4 == "???") return new string[] { "Huh? Who's There????", "Sorry there, kid. I can barely see ya.", "Say, you probably have good vision....", "Can you read all those signs with the small text for me? I'd really like to know what's on them." };
            else if (quest4 == "Return to the Old Man and give him your knowledge") return new string[] { "Wow, those signs are useless!", "Thanks for the help kid, couldn't have done it without ya!", "If you need anything, just give me a shout." };
            else if (quest4 == "Quest Completed!") return new string[] { "Money? Sorry kid I spent it all at the casino aross the block.", "That's actually why I'm here, regretting all my past life decisions", "Always put it on red, kid...." };
            else return new string[] { "I don't mean to be rude, but there are actually 5 different signs.", "You can count to 5, right?", "What do they teach you in that school?" };
        }
        if (npc.name == "Uma")
        {
            if (quest5 == "???") return new string[] { "(You come across a Strange Girl with Horse ears and a tail who doesn't speak english)", "(She seems rather upset for some reason.)", "(Maybe some Carrots from around the park will help)" };
            else if (quest5 == "Bring the carrots to the Strange Horse Girl") return new string[] { "(You give the Girl your Carrots, she seem elated)", "(You wait for some kind of reward, but Horses are not bound to Capitalism, she does let you pet her)", "*Happy Horse Noises*" };
            else if (quest5 == "Quest Completed!") return new string[] { "(You pet the Strange Horse Girl again)", "(And again)", "(She seems happy)" };
            else return new string[] { "(You stare at the Horse Girl, and she stares at you back)", "...", "(Maybe you should get those Carrots?)" };
        }
        return new string[] { "Sam, if you see this, then I'm sorry cause you shouldn't be able to", "So ummmmmmmmmmmmmmm", "You'll still give me a good grade right?" };
    }

    private void RefreshQuestNames()
    {
        questText.text = "Quests:" +
            $"\n{quest1}" +
            $"\n{quest2}" +
            $"\n{quest3}" +
            $"\n{quest4}" +
            $"\n{quest5}";
    }
}
