<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link>
      <span v-if="isLoggedIn">|<a @click="logout">Logout</a></span>
    </div>
    <router-view/>
  </div>
</template>

<script>
export default {
  computed :{
    isLoggedIn : function () { return false
    }
  }
}
</script>

<style>
</style>
