package org.dspace.content.factory;

import org.dspace.content.service.*;
import org.springframework.beans.factory.annotation.Autowired;

/**
 * User: kevin (kevin at atmire.com)
 * Date: 2/06/14
 * Time: 10:56
 */
public class ContentServiceFactoryImpl extends ContentServiceFactory {

    @Autowired(required = true)
    private BitstreamFormatService bitstreamFormatService;
    @Autowired(required = true)
    private BitstreamService bitstreamService;
    @Autowired(required = true)
    private BundleService bundleService;
    @Autowired(required = true)
    private ItemService itemService;
    @Autowired(required = true)
    private CollectionService collectionService;
    @Autowired(required = true)
    private CommunityService communityService;
    @Autowired(required = true)
    private MetadataSchemaService metadataSchemaService;
    @Autowired(required = true)
    private MetadataFieldService metadataFieldService;
    @Autowired(required = true)
    private MetadataValueService metadataValueService;
    @Autowired(required = true)
    private WorkspaceItemService workspaceItemService;
    @Autowired(required = true)
    private SubscriptionService subscriptionService;
    @Autowired(required = true)
    private InstallItemService installItemService;
    @Autowired(required = true)
    private SupervisedItemService supervisedItemService;
    @Autowired(required = true)
    private SiteService siteService;


    @Override
    public BitstreamFormatService getBitstreamFormatService()
    {
        return bitstreamFormatService;
    }

    @Override
    public BitstreamService getBitstreamService()
    {
        return bitstreamService;
    }

    @Override
    public BundleService getBundleService()
    {
        return bundleService;
    }

    @Override
    public CollectionService getCollectionService()
    {
        return collectionService;
    }

    @Override
    public CommunityService getCommunityService()
    {
        return communityService;
    }

    @Override
    public ItemService getItemService()
    {
        return itemService;
    }

    @Override
    public MetadataSchemaService getMetadataSchemaService()
    {
        return metadataSchemaService;
    }

    @Override
    public MetadataFieldService getMetadataFieldService()
    {
        return metadataFieldService;
    }

    @Override
    public MetadataValueService getMetadataValueService()
    {
        return metadataValueService;
    }

    @Override
    public WorkspaceItemService getWorkspaceItemService()
    {
        return workspaceItemService;
    }

    @Override
    public SubscriptionService getSubscriptionService() {
        return subscriptionService;
    }

    @Override
    public InstallItemService getInstallItemService() {
        return installItemService;
    }

    @Override
    public SupervisedItemService getSupervisedItemService() {
        return supervisedItemService;
    }

    @Override
    public SiteService getSiteService() {
        return siteService;
    }
}
