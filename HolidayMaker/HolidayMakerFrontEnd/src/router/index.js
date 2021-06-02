import { createRouter, createWebHistory } from "vue-router";
import HelloWorld from "/src/components/HelloWorld.vue";
import Info from "../components/pages/HotelViewComponents/Info.vue";
import HotelView from "/src/components/pages/HotelView.vue";
import Rooms from "../components/pages/HotelViewComponents/Rooms.vue";
import Photos from "../components/pages/HotelViewComponents/Photos.vue";
import Reviews from "../components/pages/HotelViewComponents/Reviews.vue";
import SearchResult from "../components/pages/SearchResult.vue";
import AddReview from "../components/pages/HotelViewComponents/ReviewComponents/AddReview.vue";
import OrderCompletedView from "../components/pages/OrderCompletedView.vue";
import CheckoutView from "../components/pages/CheckoutView.vue";
import Body from "../components/pages/MainPage/Body.vue";
import { registerRuntimeCompiler } from "@vue/runtime-core";
import Home from "/src/components/pages/Home.vue";
import ReservationDetails from "/src/components/pages/ReservationDetails.vue";
import CustomerDetails from '/src/components/pages/CheckoutViewComponents/CustomerDetails.vue'
import OrderDetails from '/src/components/pages/CheckoutViewComponents/OrderDetails.vue'
import StripePayment from '/src/components/pages/CheckoutViewComponents/StripePayment.vue'
import OrderConfirmed from '/src/components/pages/CheckoutViewComponents/OrderConfirmed.vue'

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/result",
    name: "result",
    component: SearchResult,
  },
  {
    path: "/addReview",
    name: "addReview",
    component: AddReview,
  },
  {
    path: "/hotels/:id",
    name: "hotels",
    component: HotelView,
    children: [
      {
        path: "",
        component: Info,
      },
      {
        path: "rooms",
        name: "hotels",
        component: Rooms,
      },
      {
        path: "Photos",
        name: "photos",
        component: Photos,
      },
      {
        path: "Reviews",
        name: "reviews",
        component: Reviews,
      },
    ],
  },
  {
    path: "/orderCompleted",
    name: "OrderCompleted",
    component: OrderCompletedView,
  },
  {
    path: "/checkout",
    name: "Checkout",
    component: CheckoutView,
    children: [
      {
        path: "",
        name: "customerDetails",
        component: CustomerDetails,
      },
      {
        path: "orderDetails",
        name: "OrderDetails",
        component: OrderDetails,
      },
      {
        path: "payment",
        name: "Payment",
        component: StripePayment,
      },
      {
        path: "orderConfirmed",
        name: "OrderConfirmed",
        component: OrderConfirmed,
      }
    ]
  },
  {
    path: "/reservationdetails/:id",
    name: "reservationdetails",
    component: ReservationDetails,
  },
];
const router = createRouter({
  history: createWebHistory(),
  routes,
});
export default router;
