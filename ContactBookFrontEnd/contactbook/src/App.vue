<template>
  <div id="app">
    <ContactBookMain></ContactBookMain>
  </div>
</template>

<script lang="ts">
import ContactBookMain from "./views/ContactBook.vue";

export default {
  name: "App",
  components: {
    ContactBookMain
  }
}
</script>

<style lang="scss">
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  font-size: 25px;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

}

</style>
