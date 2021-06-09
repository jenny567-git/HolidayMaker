<template>
    <div class="card mb-3">
    <!-- style="max-width: 540px;" (in style)-->
    <div class="row g-0">
      <div class="col-md-4">
        <img
          :src="hotel.hotelImg"
          alt="..."
          class="img-fluid"
        />
      </div>
      <div class="col-md-8">
        <div class="card-body">
          <button
            class="btn btn-danger btn-sm rounded-0 float-end"
            type="button"
            data-toggle="tooltip"
            data-placement="top"
            title="Delete"
          >
            <i class="fa fa-trash"></i>
          </button>
          <h5 class="card-title">{{hotel.hotelName}}</h5>
          <div class="textS">
            {{hotel.hotelDescription}}
          </div>
          <router-link :to="'/hotels/' + hotel.hotelId">
                <Button class="p-button-info mt-2" label="See Hotel"></Button>
            </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Button from "primevue/button";

export default {
  components:{
    Button
  },
  props:{
      hotel: {}
  },
  created(){
    // console.log('this hotel', this.hotel);
    // console.log('img: ', this.hotel.hotelImg);
  }
}
</script>