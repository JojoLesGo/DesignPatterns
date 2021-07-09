using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using State_Design_Pattern.UI;

namespace State_Design_Pattern.Logic
{
    public class Booking
    {
        private MainWindow View { get;  set; }
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }

        private CancellationTokenSource cancelToken;

        private bool isNew;
        private bool isPending;
        private bool isBooked;
       
        public Booking(MainWindow view)
        {
            isNew = true;
            View = view;
            BookingID = new Random().Next();
            ShowState("New");
            View.ShowEntryPage();
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            if (isNew)
            {
                isNew = false;
                isPending = true;

                
            }
        }

        public void Cancel()
        {
            if (isNew)
            {
                
            }
            else if (isPending)
            {
                cancelToken.Cancel();
            }
            else if (isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking cancelled. Expect a refund.");
                isBooked = false;
            }
            else
            {
                View.ShowError("Closed bookings cannot be canceled");
            }
        }

        public void DatePassed()
        {
            if (isNew)
            {
                
                isNew = false;
            }
            else if (isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("We hope you enjoyed the event");
                isBooked = false;
            }
            else
            {
                View.ShowError("Closed bookings cannot be canceled");
            }
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            isPending = false;
            switch (result)
            {
                case ProcessingResult.Success:
                    isBooked = true;
                    ShowState("Booked");
                    View.ShowStatusPage("Enjoy the Event");
                    break;
                case ProcessingResult.Fail:
                    isNew = true;
                    View.ShowProcessingError();
                    Attendee = string.Empty;
                    BookingID = new Random().Next();
                    ShowState("New");
                    View.ShowEntryPage();
                    break;
                case ProcessingResult.Cancel:
                    ShowState("Closed");
                    View.ShowStatusPage("Processing Canceled");
                    break;
            }
        }

        public void ShowState(string stateName)
        {
            View.grdDetails.Visibility = System.Windows.Visibility.Visible;
            View.lblCurrentState.Content = stateName;
            View.lblTicketCount.Content = TicketCount;
            View.lblAttendee.Content = Attendee;
            View.lblBookingID.Content = BookingID;
        }

      

    }
}


