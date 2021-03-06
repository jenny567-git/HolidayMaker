<template>
  <div>
    <p id="title">
      <b>Total price: {{ totalPrice }} SEK</b>
    </p>
    <div id="center">
      <form id="payment-form">
        <div id="card-element">
          <!--Stripe.js injects the Card Element-->
        </div>
        <button id="submit" class="btn btn-primary stripe-btn">
          <div class="spinner hidden" id="spinner"></div>
          <span id="button-text">Pay now</span>
        </button>
        <p id="card-error" role="alert"></p>
        <p class="result-message hidden">
          Payment succeeded, finishing booking.
        </p>
      </form>
    </div>
  </div>
</template>
<script>
var stripe = Stripe(
  "pk_test_51Ix5jxB3kuAuBTpuGWxPqbLVlnLXyBSYwkwxwkxL03O0cnmIymQwpe03cVY6QTVeH3Qm3QU9RHPHP2AbYgsUnbcu001gSH8cIe"
);
var elements = stripe.elements();
var card = undefined;
// Set up Stripe.js and Elements to use in checkout form
var style = {
  base: {
    color: "#32325d",
    fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
    fontSmoothing: "antialiased",
    fontSize: "16px",
    "::placeholder": {
      color: "#32325d",
    },
  },
  invalid: {
    color: "#fa755a",
    iconColor: "#fa755a",
  },
};

var purchase = {
  items: [{ id: "xl-tshirt" }],
};

import Card from "primevue/card";

export default {
  mounted() {
    if (card === undefined) {
      card = elements.create("card", { style: style });
    }
    card.mount("#card-element");
  },
  components: {
    Card,
  },
  computed: {
    totalPrice() {
      return this.$store.state.bookingDetails.totalprice;
    },
  },
  methods: {
    payWithCard(stripe, card, clientSecret) {
      loading(true);
      var ref = this;
      var email = this.$store.state.customerDetailsCheckout.email;
      stripe
        .confirmCardPayment(clientSecret, {
          receipt_email: email,
          payment_method: {
            card: card,
          },
        })
        .then(function (result) {
          if (result.error) {
            // Show error to your customer
            showError(result.error.message);
          } else {
            // The payment succeeded!
            orderComplete(result.paymentIntent.id);
            console.log("Payment Confirmed!");
            ref.createBooking();
          }
        });
    },
    createBooking() {
      var bookingDetails = this.$store.state.bookingDetails;
      var booking = {
        startDate:
          this.$store.state.searchString.dates[0].toLocaleDateString("sv-SE"),
        endDate:
          this.$store.state.searchString.dates[1].toLocaleDateString("sv-SE"),
        totalPrice: bookingDetails.totalprice,
        hotelId: this.$store.state.hotel.id,
        guestId: this.$store.state.user.id,
        adults: this.$store.state.searchString.inputAdult,
        children: this.$store.state.searchString.inputChild,
        extraBed: bookingDetails.extraBed,
        customerMessage: this.$store.state.customerDetailsCheckout.Message,
        reservationId: 0,
        type: bookingDetails.serviceType,
        reservedRooms: [],
        customerDetails: {},
      };

      booking.customerDetails = this.$store.state.customerDetailsCheckout;

      if (bookingDetails.noOfSingleRooms > 0) {
        booking.reservedRooms.push({
          roomId: bookingDetails.singleRoomId,
          bookedRooms: bookingDetails.noOfSingleRooms,
        });
      }
      if (bookingDetails.noOfDoubleRooms > 0) {
        booking.reservedRooms.push({
          roomId: bookingDetails.doubleRoomId,
          bookedRooms: bookingDetails.noOfDoubleRooms,
        });
      }
      if (bookingDetails.noOfFamilyRooms > 0) {
        booking.reservedRooms.push({
          roomId: bookingDetails.familyRoomId,
          bookedRooms: bookingDetails.noOfFamilyRooms,
        });
      }

      fetch("https://localhost:44356/api/Booking/AddBooking", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(booking),
      })
        .then((response) => response.json())
        .then((data) => {
          console.log("Success:", data);
          this.$emit("payment-confirmed", data);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    },
  },
  created() {
    // document.querySelector("button").disabled = true;
    var ref = this;
    fetch("https://localhost:44356/api/create-payment-intent", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(purchase),
    })
      .then(function (result) {
        return result.json();
      })
      .then(function (data) {
        card.on("change", function (event) {
          // Disable the Pay button if there are no card details in the Element
          // document.querySelector("button").disabled = event.empty;
          // document.querySelector("#card-error").textContent = event.error ? event.error.message : "";
        });
        var form = document.getElementById("payment-form");
        form.addEventListener("submit", function (event) {
          event.preventDefault();
          // Create the order here. Make sure it is completed!

          // Complete payment when the submit button is clicked
          ref.payWithCard(stripe, card, data.clientSecret);
        });
      });
  },
};

// UI stuff
// Shows a success message when the payment is complete
var orderComplete = function (paymentIntentId) {
  loading(false);

  document.querySelector(".result-message").classList.remove("hidden");
  document.querySelector(".stripe-btn").disabled = true;
};
// Show the customer the error from Stripe if their card fails to charge
var showError = function (errorMsgText) {
  loading(false);
  var errorMsg = document.querySelector("#card-error");
  errorMsg.textContent = errorMsgText;
  setTimeout(function () {
    errorMsg.textContent = "";
  }, 4000);
};
// Show a spinner on payment submission
var loading = function (isLoading) {
  if (isLoading) {
    // Disable the button and show a spinner
    document.querySelector(".stripe-btn").disabled = true;
    document.querySelector("#spinner").classList.remove("hidden");
    document.querySelector("#button-text").classList.add("hidden");
  } else {
    document.querySelector(".stripe-btn").disabled = false;
    document.querySelector("#spinner").classList.add("hidden");
    document.querySelector("#button-text").classList.remove("hidden");
  }
};
</script>
<style scoped>
* {
  box-sizing: border-box;
}

p {
  color: black;
}

#title {
  margin-top: 25px;
}

#center {
  display: flex;
  justify-content: center;
}

body {
  font-family: -apple-system, BlinkMacSystemFont, sans-serif;
  font-size: 16px;
  -webkit-font-smoothing: antialiased;
  display: flex;
  justify-content: center;
  align-content: center;
  height: 100vh;
  width: 100vw;
}
form {
  margin: 0 auto;
  width: 80%;
  min-width: 300px;
  align-self: center;
  box-shadow: 0px 0px 0px 0.5px rgba(50, 50, 93, 0.1),
    0px 2px 5px 0px rgba(50, 50, 93, 0.1), 0px 1px 1.5px 0px rgba(0, 0, 0, 0.07);
  border-radius: 7px;
}
input {
  border-radius: 6px;
  margin-bottom: 6px;
  padding: 12px;
  border: 1px solid rgba(50, 50, 93, 0.1);
  height: 44px;
  font-size: 16px;
  width: 100%;
  background: white;
}
.result-message {
  line-height: 22px;
  font-size: 16px;
}
.result-message a {
  color: rgb(89, 111, 214);
  font-weight: 600;
  text-decoration: none;
}
.hidden {
  display: none;
}
#card-error {
  color: rgb(105, 115, 134);
  text-align: left;
  font-size: 13px;
  line-height: 17px;
  margin-top: 12px;
}
#card-element {
  border-radius: 4px 4px 0 0;
  padding: 12px;
  border: 1px solid rgba(50, 50, 93, 0.1);
  height: 44px;
  width: 100%;
  background: white;
}
#payment-request-button {
  margin-bottom: 32px;
}
/* Buttons and links */
button {
  background: #5469d4;
  color: #ffffff;
  font-family: Arial, sans-serif;
  border-radius: 0 0 4px 4px;
  border: 0;
  padding: 12px 16px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  display: block;
  transition: all 0.2s ease;
  box-shadow: 0px 4px 5.5px 0px rgba(0, 0, 0, 0.07);
  width: 100%;
}
button:hover {
  filter: contrast(115%);
}
button:disabled {
  opacity: 0.5;
  cursor: default;
}
/* spinner/processing state, errors */
.spinner,
.spinner:before,
.spinner:after {
  border-radius: 50%;
}
.spinner {
  color: #ffffff;
  font-size: 22px;
  text-indent: -99999px;
  margin: 0px auto;
  position: relative;
  width: 20px;
  height: 20px;
  box-shadow: inset 0 0 0 2px;
  -webkit-transform: translateZ(0);
  -ms-transform: translateZ(0);
  transform: translateZ(0);
}
.spinner:before,
.spinner:after {
  position: absolute;
  content: "";
}
.spinner:before {
  width: 10.4px;
  height: 20.4px;
  background: #5469d4;
  border-radius: 20.4px 0 0 20.4px;
  top: -0.2px;
  left: -0.2px;
  -webkit-transform-origin: 10.4px 10.2px;
  transform-origin: 10.4px 10.2px;
  -webkit-animation: loading 2s infinite ease 1.5s;
  animation: loading 2s infinite ease 1.5s;
}
.spinner:after {
  width: 10.4px;
  height: 10.2px;
  background: #5469d4;
  border-radius: 0 10.2px 10.2px 0;
  top: -0.1px;
  left: 10.2px;
  -webkit-transform-origin: 0px 10.2px;
  transform-origin: 0px 10.2px;
  -webkit-animation: loading 2s infinite ease;
  animation: loading 2s infinite ease;
}
@-webkit-keyframes loading {
  0% {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@keyframes loading {
  0% {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@media only screen and (max-width: 600px) {
  form {
    width: 80vw;
  }
}
</style>