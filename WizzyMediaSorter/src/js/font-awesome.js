import { library, dom } from '@fortawesome/fontawesome-svg-core';
import { faPen } from '@fortawesome/pro-solid-svg-icons/faPen';
import { faTrashAlt } from '@fortawesome/pro-solid-svg-icons/faTrashAlt';
import { faFolderPlus } from '@fortawesome/pro-solid-svg-icons/faFolderPlus';
import { faPlusCircle } from '@fortawesome/pro-solid-svg-icons/faPlusCircle';
import { faTag } from '@fortawesome/pro-solid-svg-icons/faTag';


library.add(
    faPen,
    faTrashAlt,
    faFolderPlus,
    faPlusCircle,
    faTag
);
dom.watch();