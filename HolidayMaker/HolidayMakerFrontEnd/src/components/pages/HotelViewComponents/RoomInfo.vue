<template>
  <div class="container">
    <div class="row">
      
      <!-- left column -->
      <div class="col-md-6">
        <ul class="list-group list-group-flush">
          <li class="list-group-item">
            <div class="row">
              <div class="col">
                <Images/>
              </div>
              <div class="col">
                <h3>(room type 1)</h3>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <p>Max Capacity: (room.maxCapatiy) 
                    <i class="fas fa-user-alt"></i>
                  </p>
                </div>
                <div class="col-md-6">
                  <p>Rooms: 
                    <input type="number" min="0" value="0" />
                </p>
                </div>
              </div>
              <div class="row">
                    <div class="col-md-6">
                      <p>Price/unit:</p>
                    </div>
                    <div class="col-md-6">
                        <p style="color: red">214 SEK</p>
                    </div>
              </div>
            </div>
          </li>


          <li class="list-group-item">
            <div class="row">
              <div class="col">
                <Images/>
              </div>
              <div class="col">
                <h3>(room type 1)</h3>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <p>Max Capacity: (room.maxCapatiy) 
                    <i class="fas fa-user-alt"></i>
                  </p>
                </div>
                <div class="col-md-6">
                  <p>Rooms: 
                    <input type="number" min="0" value="0" />
                </p>
                </div>
              </div>
              <div class="row">
                    <div class="col-md-6">
                      <p>Price/unit:</p>
                    </div>
                    <div class="col-md-6">
                        <p style="color: red">214 SEK</p>
                    </div>
              </div>
            </div>
          </li>
          
        </ul>
        <router-link to="/hotels/1/Photos">Hotel 1 Photos </router-link>
      </div>

<!-- right column -->
      <div class="col-md-6">
        <h3>Options</h3>
        <div class="row">
          <div class="input-group mb-3">
            <div class="input-group-text">
              <input
                class="form-check-input mt-0" type="checkbox" value="" aria-label="Checkbox for following text input"/>
            </div>
            <input type="text" value="Extra beds" class="form-control" aria-label="Text input with checkbox"/>
          </div>
          <!-- Amount
          <input type="number" min="1" value="1" /> -->
        </div>

        <!-- Pension type -->
        <div class="row">
          <h3>Service type:</h3>
          <div class="btn-group" role="group" aria-label="Basic radio toggle button group">
            <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" checked/>
            <label class="btn btn-outline-primary" for="btnradio1">
              Self service
              </label>

            <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off" />
            <label class="btn btn-outline-primary" for="btnradio2">
              Half board
              </label>

            <input type="radio" class="btn-check" name="btnradio" id="btnradio3" autocomplete="off" />
            <label class="btn btn-outline-primary" for="btnradio3">
              Full board
              </label>

              <input type="radio" class="btn-check" name="btnradio" id="btnradio4" autocomplete="off" />
            <label class="btn btn-outline-primary" for="btnradio4">
              All inclusive
              </label>
          </div>
        </div>
        <div class="row pt-5">
          <div class="col-md-6">
              <p>Total price: 1223 SEK</p>
          </div>
          <div class="col-md-6">
              <button type="button" class="btn btn-primary">Book</button>
          </div>
        </div>
      </div>
      
    </div>
    
  </div>
</template>

<script>
import Images from './RoomPhotoSlider.vue'

export default {
components: {
    Images
  }
}
</script>
