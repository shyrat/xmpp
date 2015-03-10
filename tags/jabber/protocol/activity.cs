// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="activity.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Activity
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/activity";

        public static readonly XName Activity = XName.Get("activity", Name);
        public static readonly XName DoingChores = XName.Get("doing_chores", Name);
        public static readonly XName Drinking = XName.Get("drinking", Name);
        public static readonly XName Eating = XName.Get("eating", Name);
        public static readonly XName Exercising = XName.Get("exercising", Name);
        public static readonly XName Grooming = XName.Get("grooming", Name);
        public static readonly XName HavingAppointment = XName.Get("having_appointment", Name);
        public static readonly XName Inactive = XName.Get("inactive", Name);
        public static readonly XName Relaxing = XName.Get("relaxing", Name);
        public static readonly XName Talking = XName.Get("talking", Name);
        public static readonly XName Traveling = XName.Get("traveling", Name);
        public static readonly XName Working = XName.Get("working", Name);
        public static readonly XName Text = XName.Get("text", Name);
        public static readonly XName AtTheSpa = XName.Get("at_the_spa", Name);
        public static readonly XName BrushingTeeth = XName.Get("brushing_teeth", Name);
        public static readonly XName BuyingGroceries = XName.Get("buying_groceries", Name);
        public static readonly XName Cleaning = XName.Get("cleaning", Name);
        public static readonly XName Coding = XName.Get("coding", Name);
        public static readonly XName Commuting = XName.Get("commuting", Name);
        public static readonly XName Cooking = XName.Get("cooking", Name);
        public static readonly XName Cycling = XName.Get("cycling", Name);
        public static readonly XName DayOff = XName.Get("day_off", Name);
        public static readonly XName DoingMaintenance = XName.Get("doing_maintenance", Name);
        public static readonly XName DoingTheDishes = XName.Get("doing_the_dishes", Name);
        public static readonly XName DoingTheLaundry = XName.Get("doing_the_laundry", Name);
        public static readonly XName Driving = XName.Get("driving", Name);
        public static readonly XName Gaming = XName.Get("gaming", Name);
        public static readonly XName Gardening = XName.Get("gardening", Name);
        public static readonly XName GettingAHaircut = XName.Get("getting_a_haircut", Name);
        public static readonly XName GoingOut = XName.Get("going_out", Name);
        public static readonly XName HangingOut = XName.Get("hanging_out", Name);
        public static readonly XName HavingABeer = XName.Get("having_a_beer", Name);
        public static readonly XName HavingASnack = XName.Get("having_a_snack", Name);
        public static readonly XName HavingBreakfast = XName.Get("having_breakfast", Name);
        public static readonly XName HavingCoffee = XName.Get("having_coffee", Name);
        public static readonly XName HavingDinner = XName.Get("having_dinner", Name);
        public static readonly XName HavingLunch = XName.Get("having_lunch", Name);
        public static readonly XName HavingTea = XName.Get("having_tea", Name);
        public static readonly XName Hiking = XName.Get("hiking", Name);
        public static readonly XName InACar = XName.Get("in_a_car", Name);
        public static readonly XName InAMeeting = XName.Get("in_a_meeting", Name);
        public static readonly XName InRealLife = XName.Get("in_real_life", Name);
        public static readonly XName Jogging = XName.Get("jogging", Name);
        public static readonly XName OnABus = XName.Get("on_a_bus", Name);
        public static readonly XName OnAPlane = XName.Get("on_a_plane", Name);
        public static readonly XName OnATrain = XName.Get("on_a_train", Name);
        public static readonly XName OnATrip = XName.Get("on_a_trip", Name);
        public static readonly XName OnThePhone = XName.Get("on_the_phone", Name);
        public static readonly XName OnVacation = XName.Get("on_vacation", Name);
        public static readonly XName Other = XName.Get("other", Name);
        public static readonly XName Partying = XName.Get("partying", Name);
        public static readonly XName PlayingSports = XName.Get("playing_sports", Name);
        public static readonly XName Reading = XName.Get("reading", Name);
        public static readonly XName Rehearsing = XName.Get("rehearsing", Name);
        public static readonly XName Running = XName.Get("running", Name);
        public static readonly XName RunningAnErrand = XName.Get("running_an_errand", Name);
        public static readonly XName ScheduledHoliday = XName.Get("scheduled_holiday", Name);
        public static readonly XName Shaving = XName.Get("shaving", Name);
        public static readonly XName Shopping = XName.Get("shopping", Name);
        public static readonly XName Skiing = XName.Get("skiing", Name);
        public static readonly XName Sleeping = XName.Get("sleeping", Name);
        public static readonly XName Socializing = XName.Get("socializing", Name);
        public static readonly XName Studying = XName.Get("studying", Name);
        public static readonly XName Sunbathing = XName.Get("sunbathing", Name);
        public static readonly XName Swimming = XName.Get("swimming", Name);
        public static readonly XName TakingABath = XName.Get("taking_a_bath", Name);
        public static readonly XName TakingAShower = XName.Get("taking_a_shower", Name);
        public static readonly XName Walking = XName.Get("walking", Name);
        public static readonly XName WalkingTheDog = XName.Get("walking_the_dog", Name);
        public static readonly XName WatchingTv = XName.Get("watching_tv", Name);
        public static readonly XName WatchingAMovie = XName.Get("watching_a_movie", Name);
        public static readonly XName WorkingOut = XName.Get("working_out", Name);
        public static readonly XName Writing = XName.Get("writing", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Activity))]
    public class Activity : Tag
    {
        public Activity() : base(Namespace.Activity)
        {
        }

        public Activity(XElement other)
            : base(other)
        {
        }

        public IEnumerable<DoingChores> DoingChoresElements
        {
            get { return Elements<DoingChores>(Namespace.DoingChores); }
        }

        public IEnumerable<Drinking> DrinkingElements
        {
            get { return Elements<Drinking>(Namespace.Drinking); }
        }

        public IEnumerable<Eating> EatingElements
        {
            get { return Elements<Eating>(Namespace.Eating); }
        }

        public IEnumerable<Exercising> ExercisingElements
        {
            get { return Elements<Exercising>(Namespace.Exercising); }
        }

        public IEnumerable<Grooming> GroomingElements
        {
            get { return Elements<Grooming>(Namespace.Grooming); }
        }

        public IEnumerable<HavingAppointment> HavingAppointmentElements
        {
            get { return Elements<HavingAppointment>(Namespace.HavingAppointment); }
        }

        public IEnumerable<Inactive> InactiveElements
        {
            get { return Elements<Inactive>(Namespace.Inactive); }
        }

        public IEnumerable<Relaxing> RelaxingElements
        {
            get { return Elements<Relaxing>(Namespace.Relaxing); }
        }

        public IEnumerable<Talking> TalkingElements
        {
            get { return Elements<Talking>(Namespace.Talking); }
        }

        public IEnumerable<Traveling> TravelingElements
        {
            get { return Elements<Traveling>(Namespace.Traveling); }
        }

        public IEnumerable<Working> WorkingElements
        {
            get { return Elements<Working>(Namespace.Working); }
        }

        public IEnumerable<Text> TextElements
        {
            get { return Elements<Text>(Namespace.Text); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Text))]
    public class Text : Tag
    {
        public Text() : base(Namespace.Text)
        {
        }

        public Text(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(DoingChores))]
    public class DoingChores : Tag
    {
        public DoingChores() : base(Namespace.DoingChores)
        {
        }

        public DoingChores(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Drinking))]
    public class Drinking : Tag
    {
        public Drinking() : base(Namespace.Drinking)
        {
        }

        public Drinking(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Eating))]
    public class Eating : Tag
    {
        public Eating() : base(Namespace.Eating)
        {
        }

        public Eating(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Exercising))]
    public class Exercising : Tag
    {
        public Exercising() : base(Namespace.Exercising)
        {
        }

        public Exercising(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Grooming))]
    public class Grooming : Tag
    {
        public Grooming()
            : base(Namespace.Grooming)
        {
        }

        public Grooming(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingAppointment))]
    public class HavingAppointment : Tag
    {
        public HavingAppointment() : base(Namespace.HavingAppointment)
        {
        }

        public HavingAppointment(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Inactive))]
    public class Inactive : Tag
    {
        public Inactive() : base(Namespace.Inactive)
        {
        }

        public Inactive(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Relaxing))]
    public class Relaxing : Tag
    {
        public Relaxing() : base(Namespace.Relaxing)
        {
        }

        public Relaxing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Talking))]
    public class Talking : Tag
    {
        public Talking() : base(Namespace.Talking)
        {
        }

        public Talking(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Traveling))]
    public class Traveling : Tag
    {
        public Traveling() : base(Namespace.Traveling)
        {
        }

        public Traveling(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Working))]
    public class Working : Tag
    {
        public Working() : base(Namespace.Working)
        {
        }

        public Working(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(AtTheSpa))]
    public class AtTheSpa : Tag
    {
        public AtTheSpa() : base(Namespace.AtTheSpa)
        {
        }

        public AtTheSpa(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(BrushingTeeth))]
    public class BrushingTeeth : Tag
    {
        public BrushingTeeth() : base(Namespace.BrushingTeeth)
        {
        }

        public BrushingTeeth(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(BuyingGroceries))]
    public class BuyingGroceries : Tag
    {
        public BuyingGroceries() : base(Namespace.BuyingGroceries)
        {
        }

        public BuyingGroceries(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Cleaning))]
    public class Cleaning : Tag
    {
        public Cleaning() : base(Namespace.Cleaning)
        {
        }

        public Cleaning(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Coding))]
    public class Coding : Tag
    {
        public Coding() : base(Namespace.Coding)
        {
        }

        public Coding(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Commuting))]
    public class Commuting : Tag
    {
        public Commuting() : base(Namespace.Commuting)
        {
        }

        public Commuting(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Cooking))]
    public class Cooking : Tag
    {
        public Cooking() : base(Namespace.Cooking)
        {
        }

        public Cooking(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Cycling))]
    public class Cycling : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cycling"/> class.
        /// </summary>
        public Cycling() : base(Namespace.Cycling)
        {
        }

        public Cycling(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(DayOff))]
    public class DayOff : Tag
    {
        public DayOff() : base(Namespace.DayOff)
        {
        }

        public DayOff(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(DoingMaintenance))]
    public class DoingMaintenance : Tag
    {
        public DoingMaintenance() : base(Namespace.DoingMaintenance)
        {
        }

        public DoingMaintenance(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(DoingTheDishes))]
    public class DoingTheDishes : Tag
    {
        public DoingTheDishes() : base(Namespace.DoingTheDishes)
        {
        }

        public DoingTheDishes(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(DoingTheLaundry))]
    public class DoingTheLaundry : Tag
    {
        public DoingTheLaundry() : base(Namespace.DoingTheLaundry)
        {
        }

        public DoingTheLaundry(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Driving))]
    public class Driving : Tag
    {
        public Driving() : base(Namespace.Driving)
        {
        }

        public Driving(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Gaming))]
    public class Gaming : Tag
    {
        public Gaming() : base(Namespace.Gaming)
        {
        }

        public Gaming(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Gardening))]
    public class Gardening : Tag
    {
        public Gardening() : base(Namespace.Gardening)
        {
        }

        public Gardening(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(GettingAHaircut))]
    public class GettingAHaircut : Tag
    {
        public GettingAHaircut() : base(Namespace.GettingAHaircut)
        {
        }

        public GettingAHaircut(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(GoingOut))]
    public class GoingOut : Tag
    {
        public GoingOut() : base(Namespace.GoingOut)
        {
        }

        public GoingOut(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HangingOut))]
    public class HangingOut : Tag
    {
        public HangingOut() : base(Namespace.HangingOut)
        {
        }

        public HangingOut(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingABeer))]
    public class HavingABeer : Tag
    {
        public HavingABeer() : base(Namespace.HavingABeer)
        {
        }

        public HavingABeer(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingASnack))]
    public class HavingASnack : Tag
    {
        public HavingASnack() : base(Namespace.HavingASnack)
        {
        }

        public HavingASnack(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingBreakfast))]
    public class HavingBreakfast : Tag
    {
        public HavingBreakfast() : base(Namespace.HavingBreakfast)
        {
        }

        public HavingBreakfast(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingCoffee))]
    public class HavingCoffee : Tag
    {
        public HavingCoffee() : base(Namespace.HavingCoffee)
        {
        }

        public HavingCoffee(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingDinner))]
    public class HavingDinner : Tag
    {
        public HavingDinner() : base(Namespace.HavingDinner)
        {
        }

        public HavingDinner(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingLunch))]
    public class HavingLunch : Tag
    {
        public HavingLunch() : base(Namespace.HavingLunch)
        {
        }

        public HavingLunch(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HavingTea))]
    public class HavingTea : Tag
    {
        public HavingTea() : base(Namespace.HavingTea)
        {
        }

        public HavingTea(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Hiking))]
    public class Hiking : Tag
    {
        public Hiking() : base(Namespace.Hiking)
        {
        }

        public Hiking(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InACar))]
    public class InACar : Tag
    {
        public InACar() : base(Namespace.InACar)
        {
        }

        public InACar(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InAMeeting))]
    public class InAMeeting : Tag
    {
        public InAMeeting() : base(Namespace.InAMeeting)
        {
        }

        public InAMeeting(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InRealLife))]
    public class InRealLife : Tag
    {
        public InRealLife() : base(Namespace.InRealLife)
        {
        }

        public InRealLife(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Jogging))]
    public class Jogging : Tag
    {
        public Jogging() : base(Namespace.Jogging)
        {
        }

        public Jogging(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(OnABus))]
    public class OnABus : Tag
    {
        public OnABus() : base(Namespace.OnABus)
        {
        }

        public OnABus(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(OnAPlane))]
    public class OnAPlane : Tag
    {
        public OnAPlane() : base(Namespace.OnAPlane)
        {
        }

        public OnAPlane(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(OnATrain))]
    public class OnATrain : Tag
    {
        public OnATrain() : base(Namespace.OnATrain)
        {
        }

        public OnATrain(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(OnATrip))]
    public class OnATrip : Tag
    {
        public OnATrip() : base(Namespace.OnATrip)
        {
        }

        public OnATrip(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(OnThePhone))]
    public class OnThePhone : Tag
    {
        public OnThePhone() : base(Namespace.OnThePhone)
        {
        }

        public OnThePhone(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(OnVacation))]
    public class OnVacation : Tag
    {
        public OnVacation() : base(Namespace.OnVacation)
        {
        }

        public OnVacation(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Other))]
    public class Other : Tag
    {
        public Other() : base(Namespace.Other)
        {
        }

        public Other(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Partying))]
    public class Partying : Tag
    {
        public Partying() : base(Namespace.Partying)
        {
        }

        public Partying(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(PlayingSports))]
    public class PlayingSports : Tag
    {
        public PlayingSports() : base(Namespace.PlayingSports)
        {
        }

        public PlayingSports(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Reading))]
    public class Reading : Tag
    {
        public Reading() : base(Namespace.Reading)
        {
        }

        public Reading(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Rehearsing))]
    public class Rehearsing : Tag
    {
        public Rehearsing() : base(Namespace.Rehearsing)
        {
        }

        public Rehearsing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Running))]
    public class Running : Tag
    {
        public Running() : base(Namespace.Running)
        {
        }

        public Running(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RunningAnErrand))]
    public class RunningAnErrand : Tag
    {
        public RunningAnErrand() : base(Namespace.RunningAnErrand)
        {
        }

        public RunningAnErrand(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ScheduledHoliday))]
    public class ScheduledHoliday : Tag
    {
        public ScheduledHoliday() : base(Namespace.ScheduledHoliday)
        {
        }

        public ScheduledHoliday(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Shaving))]
    public class Shaving : Tag
    {
        public Shaving() : base(Namespace.Shaving)
        {
        }

        public Shaving(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Shopping))]
    public class Shopping : Tag
    {
        public Shopping() : base(Namespace.Shopping)
        {
        }

        public Shopping(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Skiing))]
    public class Skiing : Tag
    {
        public Skiing() : base(Namespace.Skiing)
        {
        }

        public Skiing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Sleeping))]
    public class Sleeping : Tag
    {
        public Sleeping() : base(Namespace.Sleeping)
        {
        }

        public Sleeping(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Socializing))]
    public class Socializing : Tag
    {
        public Socializing() : base(Namespace.Socializing)
        {
        }

        public Socializing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Studying))]
    public class Studying : Tag
    {
        public Studying() : base(Namespace.Studying)
        {
        }

        public Studying(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Sunbathing))]
    public class Sunbathing : Tag
    {
        public Sunbathing() : base(Namespace.Sunbathing)
        {
        }

        public Sunbathing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Swimming))]
    public class Swimming : Tag
    {
        public Swimming() : base(Namespace.Swimming)
        {
        }

        public Swimming(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(TakingABath))]
    public class TakingABath : Tag
    {
        public TakingABath() : base(Namespace.TakingABath)
        {
        }

        public TakingABath(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(TakingAShower))]
    public class TakingAShower : Tag
    {
        public TakingAShower() : base(Namespace.TakingAShower)
        {
        }

        public TakingAShower(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Walking))]
    public class Walking : Tag
    {
        public Walking() : base(Namespace.Walking)
        {
        }

        public Walking(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(WalkingTheDog))]
    public class WalkingTheDog : Tag
    {
        public WalkingTheDog() : base(Namespace.WalkingTheDog)
        {
        }

        public WalkingTheDog(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(WatchingTv))]
    public class WatchingTv : Tag
    {
        public WatchingTv() : base(Namespace.WatchingTv)
        {
        }

        public WatchingTv(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(WatchingAMovie))]
    public class WatchingAMovie : Tag
    {
        public WatchingAMovie() : base(Namespace.WatchingAMovie)
        {
        }

        public WatchingAMovie(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(WorkingOut))]
    public class WorkingOut : Tag
    {
        public WorkingOut() : base(Namespace.WorkingOut)
        {
        }

        public WorkingOut(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Writing))]
    public class Writing : Tag
    {
        public Writing() : base(Namespace.Writing)
        {
        }

        public Writing(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/activity'
    xmlns='http://jabber.org/protocol/activity'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0108: http://www.xmpp.org/extensions/xep-0108.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='activity'>
    <xs:complexType>
      <xs:sequence>
        <xs:choice>
          <xs:element name='doing_chores' type='general'/>
          <xs:element name='drinking' type='general'/>
          <xs:element name='eating' type='general'/>
          <xs:element name='exercising' type='general'/>
          <xs:element name='grooming' type='general'/>
          <xs:element name='having_appointment' type='general'/>
          <xs:element name='inactive' type='general'/>
          <xs:element name='relaxing' type='general'/>
          <xs:element name='talking' type='general'/>
          <xs:element name='traveling' type='general'/>
          <xs:element name='working' type='general'/>
        </xs:choice>
        <xs:element name='text' minOccurs='0' type='xs:string'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:complexType name='general'>
    <xs:choice minOccurs='0'>
      <xs:choice minOccurs='0'>
        <xs:element name='at_the_spa' type='specific'/>
        <xs:element name='brushing_teeth' type='specific'/>
        <xs:element name='buying_groceries' type='specific'/>
        <xs:element name='cleaning' type='specific'/>
        <xs:element name='coding' type='specific'/>
        <xs:element name='commuting' type='specific'/>
        <xs:element name='cooking' type='specific'/>
        <xs:element name='cycling' type='specific'/>
        <xs:element name='day_off' type='specific'/>
        <xs:element name='doing_maintenance' type='specific'/>
        <xs:element name='doing_the_dishes' type='specific'/>
        <xs:element name='doing_the_laundry' type='specific'/>
        <xs:element name='driving' type='specific'/>
        <xs:element name='gaming' type='specific'/>
        <xs:element name='gardening' type='specific'/>
        <xs:element name='getting_a_haircut' type='specific'/>
        <xs:element name='going_out' type='specific'/>
        <xs:element name='hanging_out' type='specific'/>
        <xs:element name='having_a_beer' type='specific'/>
        <xs:element name='having_a_snack' type='specific'/>
        <xs:element name='having_breakfast' type='specific'/>
        <xs:element name='having_coffee' type='specific'/>
        <xs:element name='having_dinner' type='specific'/>
        <xs:element name='having_lunch' type='specific'/>
        <xs:element name='having_tea' type='specific'/>
        <xs:element name='hiking' type='specific'/>
        <xs:element name='in_a_car' type='specific'/>
        <xs:element name='in_a_meeting' type='specific'/>
        <xs:element name='in_real_life' type='specific'/>
        <xs:element name='jogging' type='specific'/>
        <xs:element name='on_a_bus' type='specific'/>
        <xs:element name='on_a_plane' type='specific'/>
        <xs:element name='on_a_train' type='specific'/>
        <xs:element name='on_a_trip' type='specific'/>
        <xs:element name='on_the_phone' type='specific'/>
        <xs:element name='on_vacation' type='specific'/>
        <xs:element name='other' type='specific'/>
        <xs:element name='partying' type='specific'/>
        <xs:element name='playing_sports' type='specific'/>
        <xs:element name='reading' type='specific'/>
        <xs:element name='rehearsing' type='specific'/>
        <xs:element name='running' type='specific'/>
        <xs:element name='running_an_errand' type='specific'/>
        <xs:element name='scheduled_holiday' type='specific'/>
        <xs:element name='shaving' type='specific'/>
        <xs:element name='shopping' type='specific'/>
        <xs:element name='skiing' type='specific'/>
        <xs:element name='sleeping' type='specific'/>
        <xs:element name='socializing' type='specific'/>
        <xs:element name='studying' type='specific'/>
        <xs:element name='sunbathing' type='specific'/>
        <xs:element name='swimming' type='specific'/>
        <xs:element name='taking_a_bath' type='specific'/>
        <xs:element name='taking_a_shower' type='specific'/>
        <xs:element name='walking' type='specific'/>
        <xs:element name='walking_the_dog' type='specific'/>
        <xs:element name='watching_tv' type='specific'/>
        <xs:element name='watching_a_movie' type='specific'/>
        <xs:element name='working_out' type='specific'/>
        <xs:element name='writing' type='specific'/>
      </xs:choice>
      <xs:any namespace='##other'/>
    </xs:choice>
  </xs:complexType>

  <xs:complexType name='specific'>
    <xs:sequence minOccurs='0'>
      <xs:any namespace='##other'/>
    </xs:sequence>
  </xs:complexType>

</xs:schema>
*/