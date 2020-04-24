<template>
  <div id="app">
    <Logo></Logo>
    <div id="nav">
      <span v-if="isLoggedIn">|<a @click="logout">Logout</a></span>
    </div>
    <router-view/>
  </div>
</template>

<script>
import Logo from "./components/Logo";

export default {
  computed :{
    isLoggedIn : function () { return false
    }
  },
  components:{
    Logo
  },
}
</script>

<style>
  #app, body{
    margin: 0 !important;
    padding: 0;
  }
</style>
