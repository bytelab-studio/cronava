<template>
  <VAppBar
    flat
  >
    <VList>
      <VListItem>
A
      </VListItem>
    </VList>

    <template v-slot:append>
      <VList>
        <VListItem>
          <VBtn
            icon="mdi-magnify"
            variant="text"
            @click="globalSearch.openSearch"
          />
        </VListItem>
      </VList>
    </template>
  </VAppBar>
  <VNavigationDrawer
    permanent
    floating
  >
    <VList class="py-0">
      <template v-for="email in emails" :key="email.id">
        <EmailListItem
          :subject="email.subject"
          :received="email.received"
          :sender="email.sender"
          :active="activeMail != null && activeMail.id == email.id"
          @click="activeMail = email"
        />
      </template>
    </VList>
  </VNavigationDrawer>
  <EmailViewer
    v-if="activeMail != null"
    :subject="activeMail.subject"
    :received="activeMail.received"
    :sender="activeMail.sender"
    :content-type="activeMail.contentType"
    :content="activeMail.content"
  />
  <VContainer
    v-else
    class="d-flex justify-center align-center h-100"
  >
    <div class="text-center">
      <MissingImage/>
      <h6 class="text-h6">No mail opened</h6>
    </div>
  </VContainer>
</template>

<script setup lang="ts">
import moment, {type Moment} from "moment";
import EmailListItem from "@/components/EmailListItem.vue";
import EmailViewer from "@/components/EmailViewer.vue";
import {ref} from "vue";
import MissingImage from "@/components/MissingImage.vue";
import useGlobalSearch from "@/hooks/globalSearch";

const activeMail = ref<{
  id: number;
  subject: string;
  received: Moment;
  sender: string;
  contentType: string;
  content: string;
} | null>(null);
const emails = ref(Array.from({length: 10}).map((_, i) => ({
  id: i,
  subject: "Email " + i,
  received: moment().subtract(i, "days"),
  sender: "hwasd" + i + "@gmail.com",
  contentType: i % 2 == 0 ? "plain/text" : "html/text",
  content: `Hi Jane,

Just a quick reminder about our meeting scheduled for 2 PM tomorrow at the downtown office. Please let me know if you’re still available.

Best regards,
John`
})));
const globalSearch = useGlobalSearch();

</script>

<style scoped>

</style>
