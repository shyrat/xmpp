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

namespace XMPP.Tags.Jabber.Protocol.activity
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "http://jabber.org/protocol/activity";

        /// <summary>
        /// The activity.
        /// </summary>
        public static XName activity = XName.Get("activity", Name);

        /// <summary>
        /// The doing_chores.
        /// </summary>
        public static XName doing_chores = XName.Get("doing_chores", Name);

        /// <summary>
        /// The drinking.
        /// </summary>
        public static XName drinking = XName.Get("drinking", Name);

        /// <summary>
        /// The eating.
        /// </summary>
        public static XName eating = XName.Get("eating", Name);

        /// <summary>
        /// The exercising.
        /// </summary>
        public static XName exercising = XName.Get("exercising", Name);

        /// <summary>
        /// The grooming.
        /// </summary>
        public static XName grooming = XName.Get("grooming", Name);

        /// <summary>
        /// The having_appointment.
        /// </summary>
        public static XName having_appointment = XName.Get("having_appointment", Name);

        /// <summary>
        /// The inactive.
        /// </summary>
        public static XName inactive = XName.Get("inactive", Name);

        /// <summary>
        /// The relaxing.
        /// </summary>
        public static XName relaxing = XName.Get("relaxing", Name);

        /// <summary>
        /// The talking.
        /// </summary>
        public static XName talking = XName.Get("talking", Name);

        /// <summary>
        /// The traveling.
        /// </summary>
        public static XName traveling = XName.Get("traveling", Name);

        /// <summary>
        /// The working.
        /// </summary>
        public static XName working = XName.Get("working", Name);

        /// <summary>
        /// The text.
        /// </summary>
        public static XName text = XName.Get("text", Name);

        /// <summary>
        /// The at_the_spa.
        /// </summary>
        public static XName at_the_spa = XName.Get("at_the_spa", Name);

        /// <summary>
        /// The brushing_teeth.
        /// </summary>
        public static XName brushing_teeth = XName.Get("brushing_teeth", Name);

        /// <summary>
        /// The buying_groceries.
        /// </summary>
        public static XName buying_groceries = XName.Get("buying_groceries", Name);

        /// <summary>
        /// The cleaning.
        /// </summary>
        public static XName cleaning = XName.Get("cleaning", Name);

        /// <summary>
        /// The coding.
        /// </summary>
        public static XName coding = XName.Get("coding", Name);

        /// <summary>
        /// The commuting.
        /// </summary>
        public static XName commuting = XName.Get("commuting", Name);

        /// <summary>
        /// The cooking.
        /// </summary>
        public static XName cooking = XName.Get("cooking", Name);

        /// <summary>
        /// The cycling.
        /// </summary>
        public static XName cycling = XName.Get("cycling", Name);

        /// <summary>
        /// The day_off.
        /// </summary>
        public static XName day_off = XName.Get("day_off", Name);

        /// <summary>
        /// The doing_maintenance.
        /// </summary>
        public static XName doing_maintenance = XName.Get("doing_maintenance", Name);

        /// <summary>
        /// The doing_the_dishes.
        /// </summary>
        public static XName doing_the_dishes = XName.Get("doing_the_dishes", Name);

        /// <summary>
        /// The doing_the_laundry.
        /// </summary>
        public static XName doing_the_laundry = XName.Get("doing_the_laundry", Name);

        /// <summary>
        /// The driving.
        /// </summary>
        public static XName driving = XName.Get("driving", Name);

        /// <summary>
        /// The gaming.
        /// </summary>
        public static XName gaming = XName.Get("gaming", Name);

        /// <summary>
        /// The gardening.
        /// </summary>
        public static XName gardening = XName.Get("gardening", Name);

        /// <summary>
        /// The getting_a_haircut.
        /// </summary>
        public static XName getting_a_haircut = XName.Get("getting_a_haircut", Name);

        /// <summary>
        /// The going_out.
        /// </summary>
        public static XName going_out = XName.Get("going_out", Name);

        /// <summary>
        /// The hanging_out.
        /// </summary>
        public static XName hanging_out = XName.Get("hanging_out", Name);

        /// <summary>
        /// The having_a_beer.
        /// </summary>
        public static XName having_a_beer = XName.Get("having_a_beer", Name);

        /// <summary>
        /// The having_a_snack.
        /// </summary>
        public static XName having_a_snack = XName.Get("having_a_snack", Name);

        /// <summary>
        /// The having_breakfast.
        /// </summary>
        public static XName having_breakfast = XName.Get("having_breakfast", Name);

        /// <summary>
        /// The having_coffee.
        /// </summary>
        public static XName having_coffee = XName.Get("having_coffee", Name);

        /// <summary>
        /// The having_dinner.
        /// </summary>
        public static XName having_dinner = XName.Get("having_dinner", Name);

        /// <summary>
        /// The having_lunch.
        /// </summary>
        public static XName having_lunch = XName.Get("having_lunch", Name);

        /// <summary>
        /// The having_tea.
        /// </summary>
        public static XName having_tea = XName.Get("having_tea", Name);

        /// <summary>
        /// The hiking.
        /// </summary>
        public static XName hiking = XName.Get("hiking", Name);

        /// <summary>
        /// The in_a_car.
        /// </summary>
        public static XName in_a_car = XName.Get("in_a_car", Name);

        /// <summary>
        /// The in_a_meeting.
        /// </summary>
        public static XName in_a_meeting = XName.Get("in_a_meeting", Name);

        /// <summary>
        /// The in_real_life.
        /// </summary>
        public static XName in_real_life = XName.Get("in_real_life", Name);

        /// <summary>
        /// The jogging.
        /// </summary>
        public static XName jogging = XName.Get("jogging", Name);

        /// <summary>
        /// The on_a_bus.
        /// </summary>
        public static XName on_a_bus = XName.Get("on_a_bus", Name);

        /// <summary>
        /// The on_a_plane.
        /// </summary>
        public static XName on_a_plane = XName.Get("on_a_plane", Name);

        /// <summary>
        /// The on_a_train.
        /// </summary>
        public static XName on_a_train = XName.Get("on_a_train", Name);

        /// <summary>
        /// The on_a_trip.
        /// </summary>
        public static XName on_a_trip = XName.Get("on_a_trip", Name);

        /// <summary>
        /// The on_the_phone.
        /// </summary>
        public static XName on_the_phone = XName.Get("on_the_phone", Name);

        /// <summary>
        /// The on_vacation.
        /// </summary>
        public static XName on_vacation = XName.Get("on_vacation", Name);

        /// <summary>
        /// The other.
        /// </summary>
        public static XName other = XName.Get("other", Name);

        /// <summary>
        /// The partying.
        /// </summary>
        public static XName partying = XName.Get("partying", Name);

        /// <summary>
        /// The playing_sports.
        /// </summary>
        public static XName playing_sports = XName.Get("playing_sports", Name);

        /// <summary>
        /// The reading.
        /// </summary>
        public static XName reading = XName.Get("reading", Name);

        /// <summary>
        /// The rehearsing.
        /// </summary>
        public static XName rehearsing = XName.Get("rehearsing", Name);

        /// <summary>
        /// The running.
        /// </summary>
        public static XName running = XName.Get("running", Name);

        /// <summary>
        /// The running_an_errand.
        /// </summary>
        public static XName running_an_errand = XName.Get("running_an_errand", Name);

        /// <summary>
        /// The scheduled_holiday.
        /// </summary>
        public static XName scheduled_holiday = XName.Get("scheduled_holiday", Name);

        /// <summary>
        /// The shaving.
        /// </summary>
        public static XName shaving = XName.Get("shaving", Name);

        /// <summary>
        /// The shopping.
        /// </summary>
        public static XName shopping = XName.Get("shopping", Name);

        /// <summary>
        /// The skiing.
        /// </summary>
        public static XName skiing = XName.Get("skiing", Name);

        /// <summary>
        /// The sleeping.
        /// </summary>
        public static XName sleeping = XName.Get("sleeping", Name);

        /// <summary>
        /// The socializing.
        /// </summary>
        public static XName socializing = XName.Get("socializing", Name);

        /// <summary>
        /// The studying.
        /// </summary>
        public static XName studying = XName.Get("studying", Name);

        /// <summary>
        /// The sunbathing.
        /// </summary>
        public static XName sunbathing = XName.Get("sunbathing", Name);

        /// <summary>
        /// The swimming.
        /// </summary>
        public static XName swimming = XName.Get("swimming", Name);

        /// <summary>
        /// The taking_a_bath.
        /// </summary>
        public static XName taking_a_bath = XName.Get("taking_a_bath", Name);

        /// <summary>
        /// The taking_a_shower.
        /// </summary>
        public static XName taking_a_shower = XName.Get("taking_a_shower", Name);

        /// <summary>
        /// The walking.
        /// </summary>
        public static XName walking = XName.Get("walking", Name);

        /// <summary>
        /// The walking_the_dog.
        /// </summary>
        public static XName walking_the_dog = XName.Get("walking_the_dog", Name);

        /// <summary>
        /// The watching_tv.
        /// </summary>
        public static XName watching_tv = XName.Get("watching_tv", Name);

        /// <summary>
        /// The watching_a_movie.
        /// </summary>
        public static XName watching_a_movie = XName.Get("watching_a_movie", Name);

        /// <summary>
        /// The working_out.
        /// </summary>
        public static XName working_out = XName.Get("working_out", Name);

        /// <summary>
        /// The writing.
        /// </summary>
        public static XName writing = XName.Get("writing", Name);
    }


    /// <summary>
    /// The activity.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(activity))]
    public class activity : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="activity"/> class.
        /// </summary>
        public activity() : base(Namespace.activity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="activity"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public activity(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the doing_chores elements.
        /// </summary>
        public IEnumerable<doing_chores> doing_choresElements
        {
            get { return Elements<doing_chores>(Namespace.doing_chores); }
        }

        /// <summary>
        /// Gets the drinking elements.
        /// </summary>
        public IEnumerable<drinking> drinkingElements
        {
            get { return Elements<drinking>(Namespace.drinking); }
        }

        /// <summary>
        /// Gets the eating elements.
        /// </summary>
        public IEnumerable<eating> eatingElements
        {
            get { return Elements<eating>(Namespace.eating); }
        }

        /// <summary>
        /// Gets the exercising elements.
        /// </summary>
        public IEnumerable<exercising> exercisingElements
        {
            get { return Elements<exercising>(Namespace.exercising); }
        }

        /// <summary>
        /// Gets the grooming elements.
        /// </summary>
        public IEnumerable<grooming> groomingElements
        {
            get { return Elements<grooming>(Namespace.grooming); }
        }

        /// <summary>
        /// Gets the having_appointment elements.
        /// </summary>
        public IEnumerable<having_appointment> having_appointmentElements
        {
            get { return Elements<having_appointment>(Namespace.having_appointment); }
        }

        /// <summary>
        /// Gets the inactive elements.
        /// </summary>
        public IEnumerable<inactive> inactiveElements
        {
            get { return Elements<inactive>(Namespace.inactive); }
        }

        /// <summary>
        /// Gets the relaxing elements.
        /// </summary>
        public IEnumerable<relaxing> relaxingElements
        {
            get { return Elements<relaxing>(Namespace.relaxing); }
        }

        /// <summary>
        /// Gets the talking elements.
        /// </summary>
        public IEnumerable<talking> talkingElements
        {
            get { return Elements<talking>(Namespace.talking); }
        }

        /// <summary>
        /// Gets the traveling elements.
        /// </summary>
        public IEnumerable<traveling> travelingElements
        {
            get { return Elements<traveling>(Namespace.traveling); }
        }

        /// <summary>
        /// Gets the working elements.
        /// </summary>
        public IEnumerable<working> workingElements
        {
            get { return Elements<working>(Namespace.working); }
        }

        /// <summary>
        /// Gets the text elements.
        /// </summary>
        public IEnumerable<text> textElements
        {
            get { return Elements<text>(Namespace.text); }
        }
    }

    /// <summary>
    /// The text.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(text))]
    public class text : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="text"/> class.
        /// </summary>
        public text() : base(Namespace.text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="text"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public text(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The doing_chores.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(doing_chores))]
    public class doing_chores : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="doing_chores"/> class.
        /// </summary>
        public doing_chores() : base(Namespace.doing_chores)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="doing_chores"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public doing_chores(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The drinking.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(drinking))]
    public class drinking : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="drinking"/> class.
        /// </summary>
        public drinking() : base(Namespace.drinking)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="drinking"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public drinking(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The eating.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(eating))]
    public class eating : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="eating"/> class.
        /// </summary>
        public eating() : base(Namespace.eating)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="eating"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public eating(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The exercising.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(exercising))]
    public class exercising : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="exercising"/> class.
        /// </summary>
        public exercising() : base(Namespace.exercising)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="exercising"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public exercising(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The grooming.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(grooming))]
    public class grooming : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="grooming"/> class.
        /// </summary>
        public grooming() : base(Namespace.grooming)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="grooming"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public grooming(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_appointment.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_appointment))]
    public class having_appointment : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_appointment"/> class.
        /// </summary>
        public having_appointment() : base(Namespace.having_appointment)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_appointment"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_appointment(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The inactive.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(inactive))]
    public class inactive : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="inactive"/> class.
        /// </summary>
        public inactive() : base(Namespace.inactive)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="inactive"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public inactive(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The relaxing.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(relaxing))]
    public class relaxing : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="relaxing"/> class.
        /// </summary>
        public relaxing() : base(Namespace.relaxing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="relaxing"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public relaxing(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The talking.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(talking))]
    public class talking : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="talking"/> class.
        /// </summary>
        public talking() : base(Namespace.talking)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="talking"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public talking(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The traveling.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(traveling))]
    public class traveling : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="traveling"/> class.
        /// </summary>
        public traveling() : base(Namespace.traveling)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="traveling"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public traveling(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The working.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(working))]
    public class working : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="working"/> class.
        /// </summary>
        public working() : base(Namespace.working)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="working"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public working(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The at_the_spa.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(at_the_spa))]
    public class at_the_spa : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="at_the_spa"/> class.
        /// </summary>
        public at_the_spa() : base(Namespace.at_the_spa)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="at_the_spa"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public at_the_spa(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The brushing_teeth.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(brushing_teeth))]
    public class brushing_teeth : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="brushing_teeth"/> class.
        /// </summary>
        public brushing_teeth() : base(Namespace.brushing_teeth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="brushing_teeth"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public brushing_teeth(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The buying_groceries.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(buying_groceries))]
    public class buying_groceries : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="buying_groceries"/> class.
        /// </summary>
        public buying_groceries() : base(Namespace.buying_groceries)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="buying_groceries"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public buying_groceries(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The cleaning.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(cleaning))]
    public class cleaning : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="cleaning"/> class.
        /// </summary>
        public cleaning() : base(Namespace.cleaning)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cleaning"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public cleaning(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The coding.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(coding))]
    public class coding : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="coding"/> class.
        /// </summary>
        public coding() : base(Namespace.coding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="coding"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public coding(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The commuting.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(commuting))]
    public class commuting : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="commuting"/> class.
        /// </summary>
        public commuting() : base(Namespace.commuting)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="commuting"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public commuting(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The cooking.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(cooking))]
    public class cooking : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="cooking"/> class.
        /// </summary>
        public cooking() : base(Namespace.cooking)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cooking"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public cooking(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The cycling.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(cycling))]
    public class cycling : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="cycling"/> class.
        /// </summary>
        public cycling() : base(Namespace.cycling)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cycling"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public cycling(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The day_off.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(day_off))]
    public class day_off : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="day_off"/> class.
        /// </summary>
        public day_off() : base(Namespace.day_off)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="day_off"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public day_off(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The doing_maintenance.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(doing_maintenance))]
    public class doing_maintenance : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="doing_maintenance"/> class.
        /// </summary>
        public doing_maintenance() : base(Namespace.doing_maintenance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="doing_maintenance"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public doing_maintenance(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The doing_the_dishes.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(doing_the_dishes))]
    public class doing_the_dishes : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="doing_the_dishes"/> class.
        /// </summary>
        public doing_the_dishes() : base(Namespace.doing_the_dishes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="doing_the_dishes"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public doing_the_dishes(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The doing_the_laundry.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(doing_the_laundry))]
    public class doing_the_laundry : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="doing_the_laundry"/> class.
        /// </summary>
        public doing_the_laundry() : base(Namespace.doing_the_laundry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="doing_the_laundry"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public doing_the_laundry(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The driving.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(driving))]
    public class driving : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="driving"/> class.
        /// </summary>
        public driving() : base(Namespace.driving)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="driving"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public driving(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The gaming.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(gaming))]
    public class gaming : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="gaming"/> class.
        /// </summary>
        public gaming() : base(Namespace.gaming)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="gaming"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public gaming(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The gardening.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(gardening))]
    public class gardening : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="gardening"/> class.
        /// </summary>
        public gardening() : base(Namespace.gardening)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="gardening"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public gardening(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The getting_a_haircut.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(getting_a_haircut))]
    public class getting_a_haircut : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="getting_a_haircut"/> class.
        /// </summary>
        public getting_a_haircut() : base(Namespace.getting_a_haircut)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="getting_a_haircut"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public getting_a_haircut(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The going_out.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(going_out))]
    public class going_out : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="going_out"/> class.
        /// </summary>
        public going_out() : base(Namespace.going_out)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="going_out"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public going_out(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The hanging_out.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(hanging_out))]
    public class hanging_out : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="hanging_out"/> class.
        /// </summary>
        public hanging_out() : base(Namespace.hanging_out)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="hanging_out"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public hanging_out(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_a_beer.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_a_beer))]
    public class having_a_beer : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_a_beer"/> class.
        /// </summary>
        public having_a_beer() : base(Namespace.having_a_beer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_a_beer"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_a_beer(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_a_snack.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_a_snack))]
    public class having_a_snack : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_a_snack"/> class.
        /// </summary>
        public having_a_snack() : base(Namespace.having_a_snack)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_a_snack"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_a_snack(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_breakfast.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_breakfast))]
    public class having_breakfast : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_breakfast"/> class.
        /// </summary>
        public having_breakfast() : base(Namespace.having_breakfast)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_breakfast"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_breakfast(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_coffee.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_coffee))]
    public class having_coffee : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_coffee"/> class.
        /// </summary>
        public having_coffee() : base(Namespace.having_coffee)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_coffee"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_coffee(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_dinner.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_dinner))]
    public class having_dinner : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_dinner"/> class.
        /// </summary>
        public having_dinner() : base(Namespace.having_dinner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_dinner"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_dinner(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_lunch.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_lunch))]
    public class having_lunch : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_lunch"/> class.
        /// </summary>
        public having_lunch() : base(Namespace.having_lunch)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_lunch"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_lunch(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The having_tea.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(having_tea))]
    public class having_tea : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="having_tea"/> class.
        /// </summary>
        public having_tea() : base(Namespace.having_tea)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="having_tea"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public having_tea(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The hiking.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(hiking))]
    public class hiking : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="hiking"/> class.
        /// </summary>
        public hiking() : base(Namespace.hiking)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="hiking"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public hiking(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The in_a_car.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(in_a_car))]
    public class in_a_car : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="in_a_car"/> class.
        /// </summary>
        public in_a_car() : base(Namespace.in_a_car)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="in_a_car"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public in_a_car(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The in_a_meeting.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(in_a_meeting))]
    public class in_a_meeting : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="in_a_meeting"/> class.
        /// </summary>
        public in_a_meeting() : base(Namespace.in_a_meeting)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="in_a_meeting"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public in_a_meeting(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The in_real_life.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(in_real_life))]
    public class in_real_life : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="in_real_life"/> class.
        /// </summary>
        public in_real_life() : base(Namespace.in_real_life)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="in_real_life"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public in_real_life(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The jogging.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(jogging))]
    public class jogging : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="jogging"/> class.
        /// </summary>
        public jogging() : base(Namespace.jogging)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="jogging"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public jogging(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The on_a_bus.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(on_a_bus))]
    public class on_a_bus : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_bus"/> class.
        /// </summary>
        public on_a_bus() : base(Namespace.on_a_bus)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_bus"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public on_a_bus(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The on_a_plane.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(on_a_plane))]
    public class on_a_plane : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_plane"/> class.
        /// </summary>
        public on_a_plane() : base(Namespace.on_a_plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_plane"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public on_a_plane(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The on_a_train.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(on_a_train))]
    public class on_a_train : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_train"/> class.
        /// </summary>
        public on_a_train() : base(Namespace.on_a_train)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_train"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public on_a_train(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The on_a_trip.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(on_a_trip))]
    public class on_a_trip : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_trip"/> class.
        /// </summary>
        public on_a_trip() : base(Namespace.on_a_trip)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="on_a_trip"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public on_a_trip(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The on_the_phone.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(on_the_phone))]
    public class on_the_phone : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="on_the_phone"/> class.
        /// </summary>
        public on_the_phone() : base(Namespace.on_the_phone)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="on_the_phone"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public on_the_phone(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The on_vacation.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(on_vacation))]
    public class on_vacation : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="on_vacation"/> class.
        /// </summary>
        public on_vacation() : base(Namespace.on_vacation)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="on_vacation"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public on_vacation(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The other.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(other))]
    public class other : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="other"/> class.
        /// </summary>
        public other() : base(Namespace.other)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="other"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public other(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The partying.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(partying))]
    public class partying : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="partying"/> class.
        /// </summary>
        public partying() : base(Namespace.partying)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="partying"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public partying(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The playing_sports.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(playing_sports))]
    public class playing_sports : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="playing_sports"/> class.
        /// </summary>
        public playing_sports() : base(Namespace.playing_sports)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="playing_sports"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public playing_sports(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The reading.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(reading))]
    public class reading : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="reading"/> class.
        /// </summary>
        public reading() : base(Namespace.reading)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="reading"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public reading(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The rehearsing.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(rehearsing))]
    public class rehearsing : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="rehearsing"/> class.
        /// </summary>
        public rehearsing() : base(Namespace.rehearsing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="rehearsing"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public rehearsing(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The running.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(running))]
    public class running : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="running"/> class.
        /// </summary>
        public running() : base(Namespace.running)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="running"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public running(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The running_an_errand.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(running_an_errand))]
    public class running_an_errand : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="running_an_errand"/> class.
        /// </summary>
        public running_an_errand() : base(Namespace.running_an_errand)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="running_an_errand"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public running_an_errand(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The scheduled_holiday.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(scheduled_holiday))]
    public class scheduled_holiday : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="scheduled_holiday"/> class.
        /// </summary>
        public scheduled_holiday() : base(Namespace.scheduled_holiday)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="scheduled_holiday"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public scheduled_holiday(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The shaving.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(shaving))]
    public class shaving : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="shaving"/> class.
        /// </summary>
        public shaving() : base(Namespace.shaving)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="shaving"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public shaving(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The shopping.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(shopping))]
    public class shopping : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="shopping"/> class.
        /// </summary>
        public shopping() : base(Namespace.shopping)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="shopping"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public shopping(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The skiing.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(skiing))]
    public class skiing : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="skiing"/> class.
        /// </summary>
        public skiing() : base(Namespace.skiing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="skiing"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public skiing(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The sleeping.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(sleeping))]
    public class sleeping : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="sleeping"/> class.
        /// </summary>
        public sleeping() : base(Namespace.sleeping)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="sleeping"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public sleeping(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The socializing.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(socializing))]
    public class socializing : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="socializing"/> class.
        /// </summary>
        public socializing() : base(Namespace.socializing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="socializing"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public socializing(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The studying.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(studying))]
    public class studying : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="studying"/> class.
        /// </summary>
        public studying() : base(Namespace.studying)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="studying"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public studying(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The sunbathing.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(sunbathing))]
    public class sunbathing : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="sunbathing"/> class.
        /// </summary>
        public sunbathing() : base(Namespace.sunbathing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="sunbathing"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public sunbathing(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The swimming.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(swimming))]
    public class swimming : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="swimming"/> class.
        /// </summary>
        public swimming() : base(Namespace.swimming)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="swimming"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public swimming(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The taking_a_bath.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(taking_a_bath))]
    public class taking_a_bath : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="taking_a_bath"/> class.
        /// </summary>
        public taking_a_bath() : base(Namespace.taking_a_bath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="taking_a_bath"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public taking_a_bath(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The taking_a_shower.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(taking_a_shower))]
    public class taking_a_shower : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="taking_a_shower"/> class.
        /// </summary>
        public taking_a_shower() : base(Namespace.taking_a_shower)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="taking_a_shower"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public taking_a_shower(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The walking.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(walking))]
    public class walking : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="walking"/> class.
        /// </summary>
        public walking() : base(Namespace.walking)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="walking"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public walking(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The walking_the_dog.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(walking_the_dog))]
    public class walking_the_dog : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="walking_the_dog"/> class.
        /// </summary>
        public walking_the_dog() : base(Namespace.walking_the_dog)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="walking_the_dog"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public walking_the_dog(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The watching_tv.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(watching_tv))]
    public class watching_tv : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="watching_tv"/> class.
        /// </summary>
        public watching_tv() : base(Namespace.watching_tv)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="watching_tv"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public watching_tv(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The watching_a_movie.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(watching_a_movie))]
    public class watching_a_movie : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="watching_a_movie"/> class.
        /// </summary>
        public watching_a_movie() : base(Namespace.watching_a_movie)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="watching_a_movie"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public watching_a_movie(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The working_out.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(working_out))]
    public class working_out : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="working_out"/> class.
        /// </summary>
        public working_out() : base(Namespace.working_out)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="working_out"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public working_out(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The writing.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(writing))]
    public class writing : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="writing"/> class.
        /// </summary>
        public writing() : base(Namespace.writing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="writing"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public writing(XElement other) : base(other)
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