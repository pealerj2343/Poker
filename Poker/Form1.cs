using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        List<Card> deck = new List<Card>();

        List<Card> p1Hand = new List<Card>();

        public Form1()
        {
            InitializeComponent();
            createDeck();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void createDeck()
        {
            for(int i = 0; i < 52; i++)
            {
                deck.Add(new Card(i % 12, i / 12));
            }
        }
        private void deal()
        {
            Random rnd = new Random();
            checkDeck();
            int card = rnd.Next(0, deck.Count);
            p1Hand.Add(deck[card]);
            deck.RemoveAt(card);
            deck.TrimExcess();

            checkDeck();
            card = rnd.Next(0, deck.Count);
            p1Hand.Add(deck[card]);
            deck.RemoveAt(card);
            deck.TrimExcess();
        }
        private void checkDeck()
        {
            if(deck.Count == 0)
            {
                deal();
            }
            return;
        }

        private void displayHand()
        {
            label1.Text = p1Hand[0].Value + " " + p1Hand[0].Suit;
            label2.Text = p1Hand[1].Value + " " + p1Hand[1].Suit;
        }

        private void deal_btn_Click(object sender, EventArgs e)
        {
            deal();
            displayHand();
        }
    }
}
public class Card
{
    // ace is 0 king is 12
    private int value;
    public int Value
    {
        set
        {
            this.value = value;
        }
        get
        {
            return value;
        }
    }
    //0 is spade 1 is hearts 2 is diamonds 3 is clubs
    private int suit;
    public int Suit
    {
        set
        {
            if(value < 4 && value >= 0)
                this.suit = value;
        }
        get
        {
            return suit;
        }
    }
    Bitmap image;
    public Card(int val, int s)
    {
        value = val;
        suit = s;

    }
}
