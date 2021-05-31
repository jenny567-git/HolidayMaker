<template>
  <div id="test3">
    <div class="row">
      <div class="col">
        <Images />
      </div>
      <div class="col">
        <h3>{{ room.type }}</h3>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>
            Max Capacity: {{(room.maxCapacity)}}
            <i class="fas fa-user-alt"></i>
          </p>
        </div>
        <div class="col-md-6">
          <p>
            Rooms:
            <input type="number" min="0" value="0" />
          </p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>Price/unit:</p>
        </div>
        <div class="col-md-6">
          <p style="color: red">{{room.price}} SEK</p>
        </div>
      </div>
    </div>
    <hr />
  </div>
</template>

<script>
import Images from "./RoomPhotoSlider.vue";

export default {
  components: {
    Images,
  },
  props: {
    room: {},
  },
};
</script>

<style>
</style>