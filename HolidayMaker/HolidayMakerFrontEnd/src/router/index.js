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
import ProfileMain from "../components/pages/CustomerProfile/ProfileMain.vue";
import Login from "../components/pages/Login/Login.vue"
import Registration from "../components/pages/Login/Registration.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/Profile",
    name: "Profile",
    component: ProfileMain,
    children: [
      {
        path: "",
        component: Profile,
      },
      {
        path: "booking",
        name: "booking",
        component: Booking,
      },
      {
        path: "favorite",
        name: "favorite",
        component: SavedHotels,
      },
      {
        path: "profileSetting",
        name: "profileSetting",
        component: ProfileSetting,
      },
    ],
  },
  {
    path: "/result",
    name: "result",
    component: SearchResult,
  },
  {
    path: "/login",
    name: "login",
    component: Login,
  },
  {
    path: "/registration",
    name: "registration",
    component: Registration,
  },
  // {
  //   path: "/addReview",
  //   name: "addReview",
  //   component: AddReview,
  // },
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
      {
        path: "AddReview",
        name: "addReview",
        component: AddReview,
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
  },
  {
    path: "/reservationdetails/:id",
    name: "reservationdetails",
    component: ReservationDetails,
  },
  {
    path: "/savedHotels",
    name: "SavedHotels",
    component: SavedHotels,
  },
  
];
const router = createRouter({
  history: createWebHistory(),
  routes,
});
export default router;
