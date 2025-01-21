<template>
  <VContainer
    max-width="1200"
  >
    <h4 class="text-h4">{{ subject }}</h4>
    <div class="d-flex flex-column">
      <span>From: {{ sender }}</span>
      <span>Date: {{ received.format(config.dateFormat.value) }}</span>
      <span>ContentType: {{ contentType }}</span>
    </div>
    <div class="py-16">
      <EmailPlainTextViewer
        v-if="contentType == 'plain/text'"
        :content="content"
      />
      <div
        v-else
        class="d-flex flex-column align-center"
      >
        <h6 class="text-h6">Sorry the file could not be opened</h6>
        <MissingImage/>
      </div>
    </div>
  </VContainer>
</template>

<script setup lang="ts">
import type {Moment} from "moment/moment";
import {useConfig} from "@/hooks/config";
import EmailPlainTextViewer from "@/components/EmailViewer/EmailPlainTextViewer.vue";
import MissingImage from "@/components/MissingImage.vue";

defineProps<{
  subject: string;
  received: Moment;
  sender: string;
  active?: boolean;
  contentType: string;
  content: string;
}>();
const config = useConfig();

</script>

<style scoped>

</style>
