from Persistence.Repositories import BlobRepository


def load_from_path(path):
    return BlobRepository.load_from_path(path)


def rebuild_imagen(data, path):
    return BlobRepository.rebuild_imagen(data, path)


def save_imagen(data, numhist):
    BlobRepository.save_imagen(data, numhist, 'imagenes_procedimiento')


def delete_imagen(identificator):
    BlobRepository.delete_imagen(identificator, 'imagenes_procedimiento')


def getall_imagenes():
    return BlobRepository.getall_imagenes('imagenes_procedimiento')


def get_imagen_by_id(identificator):
    return BlobRepository.get_imagen_by_id(identificator, 'imagenes_procedimiento')
