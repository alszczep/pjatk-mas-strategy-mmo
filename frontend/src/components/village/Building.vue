<script setup lang="ts">
  import { logOut } from "../../auth/logOut"

  const { imageUrl, level } = defineProps<{
    imageUrl?: string
    level?: number
  }>()
</script>

<template>
  <div class="wrapper">
    <img :src="imageUrl" class="image" />
    <!-- <p>Level: {{ level }}</p> -->
    <div class="background" />
  </div>
</template>

<style scoped>
  .wrapper {
    display: flex;
    justify-content: space-between;
    width: 100%;
    height: 100%;
    position: relative;
  }

  .image {
    width: 100%;
    object-fit: contain;
    object-position: center bottom;
    z-index: 5;
  }
  .background {
    background-color: #a6edaa;
    width: 100%;
    height: 20px;

    position: absolute;
    bottom: 0;
    right: 0;
    left: 0;
    z-index: 4;

    clip-path: ellipse(closest-side farthest-side);
  }
</style>
